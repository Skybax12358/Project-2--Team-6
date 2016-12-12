using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayManager : MonoBehaviour {

    #region Serialized Fields
    [SerializeField]
    VideoController videoController;
    [SerializeField]
    UIController uiController;
    #endregion

    #region Private Variables
    private int inputCounter;
    private List<string> inputStringList = new List<string>();
    private VideoInputLogic videoInputLogic = new VideoInputLogic();
    private IncidentInputLogic incidentInputLogic = new IncidentInputLogic();
    private ResponseInputLogic responseInputLogic = new ResponseInputLogic();
    #endregion

    #region Gameplay Modifiers
    //True if the players are asked to input incidents before each round
    bool inputIncidents;
    #endregion


    public List<Incident> Incidents;
    public List<Response> Responses;
    public Incident currentIncident;
    public Response currentResponse;
    public GameStates currentGameState;

    public float IncidentNumber;

    public int incidentsInGame;
    public int incidentCounter;

    public float IncidentPlayTimer;
    public float ResponsePlayTimer;

    public enum GameStates
    {
        ChooseIncident,
        PlayIncident,
        ChooseResponse,
        PlayResolution
    }

    #region Singlton Pattern
    public static GamePlayManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

        // Use this for initialization
        void Start ()
    {
        uiController.Progress.image.color = Color.Lerp(Color.red, Color.green, GameManager.instance.PlayScore / uiController.MaxPoints);
        ChangeState(GameStates.ChooseIncident);
        incidentCounter = 0;
    }



    //Changes the current game state and adjusts input field visibility
    void ChangeState(GameStates _gameState)
    {
        currentGameState = _gameState;

        switch (_gameState)
        {
            case GameStates.ChooseIncident:
                uiController.ActivateIncidentInputField();
                break;
            case GameStates.ChooseResponse:
                uiController.EventChooser = Random.Range(1, 6);
                uiController.EffectedPlayer = Random.Range(1, 3);
                uiController.ActivateResponseInputField();
                break;
            case GameStates.PlayIncident:
                uiController.DeActivateInputFields();
                break;
            case GameStates.PlayResolution:
                uiController.DeActivateInputFields();
                break;
        }
    }

    //Called when the player enters input to choose incident
    public void ActivateIncident()
    {
        uiController.movieScreen.SetActive(true);
        currentIncident = incidentInputLogic.DetermineIncident(uiController.inputField_Incident.text, Incidents);
        currentIncident.Activate();
        videoController.PlayVideo(videoInputLogic.DetermineIncidentVideo(videoController.videoClips));
        //Sets the timer to the duration of the video
        IncidentPlayTimer = videoInputLogic.DetermineIncidentVideo(videoController.videoClips).duration;
        ChangeState(GameStates.PlayIncident);
        incidentCounter += 1;
    }

    //Called when the player enters input to choose response
    public void ActivateResponse()
    {
        currentResponse = responseInputLogic.DetermineResponse(uiController.inputField_Response.text, Responses);
        currentResponse.Activate();
        videoController.PlayVideo(videoInputLogic.DetermineResponseVideo(videoController.videoClips));
        //Sets the timer to the duration of the video
        ResponsePlayTimer = videoInputLogic.DetermineResponseVideo(videoController.videoClips).duration;
        ChangeState(GameStates.PlayResolution);
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateTimers();

        uiController.Progress.value = GameManager.instance.PlayScore;

        if (GameManager.instance.PlayScore > 25)
            uiController.Progress.image.color = Color.Lerp(Color.yellow, Color.green, uiController.Progress.value / uiController.MaxPoints);
        else if (GameManager.instance.PlayScore <= 25)
            uiController.Progress.image.color = Color.Lerp(Color.red, Color.yellow, uiController.Progress.value / uiController.startingPoints);



    }

    //Controls the timers that control playing input between response and incident video playbacks
    void UpdateTimers()
    {
        if(IncidentPlayTimer > 0)
        {
            IncidentPlayTimer -= Time.deltaTime;
        }
        else
        {
            if(currentGameState == GameStates.PlayIncident)
            {
                ChangeState(GameStates.ChooseResponse);
            }
        }

        if(ResponsePlayTimer > 0)
        {
            ResponsePlayTimer -= Time.deltaTime;
        }
        else
        {
            if (currentGameState == GameStates.PlayResolution)
            {
                if(incidentCounter == incidentsInGame)
                {
                    EndGame();
                }
                else
                {
                    ChangeState(GameStates.ChooseIncident);
                }
            }
        }
    }

    //Called when all the incidents have been responded to
    void EndGame()
    {
        GameManager.instance.ChangeScene(GameManager.instance.tag_OutroScene);
    }
}

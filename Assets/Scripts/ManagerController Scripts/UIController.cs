using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject movieScreen;
    public InputField inputField_Response;
    public InputField inputField_Incident;
    public Text RandomEvent;
    public Slider Progress;

    public float startingPoints;
    public float MaxPoints;
    public Image sliderFill;

    public int EventChooser;
    public int EffectedPlayer;

    // Use this for initialization
    void Start ()
    {
        movieScreen.SetActive(false);
        DeActivateInputFields();
        Progress.value = GameManager.instance.PlayScore;
        MaxPoints = 55;
        startingPoints = 25;

    }

    public void ActivateResponseInputField()
    {

        //Focuses the inputfield allowing for direct input
        inputField_Response.gameObject.SetActive(true);
        inputField_Incident.gameObject.SetActive(false);
        inputField_Response.Select();
        inputField_Response.ActivateInputField();

        if (EventChooser == 1)
            RandomEvent.text = "Suspended: " + "Player " + EffectedPlayer;
        else if (EventChooser == 2)
            RandomEvent.text = "Solo: " + "Player " + EffectedPlayer;
        else if (EventChooser == 3)
            RandomEvent.text = "Steal: " + "Player " + EffectedPlayer;
        else if (EventChooser == 4)
            RandomEvent.text = "Redraw";
        else if (EventChooser == 5)
            RandomEvent.text = "Deadline";
        else if (EventChooser == 6)
            RandomEvent.text = "Manager: " + "Player " + EffectedPlayer;
    }

    public void ActivateIncidentInputField()
    {
        RandomEvent.text = "";
        //Focuses the inputfield allowing for direct input
        inputField_Response.gameObject.SetActive(false);
        inputField_Incident.gameObject.SetActive(true);
        inputField_Incident.Select();
        inputField_Incident.ActivateInputField();
    }

    public void DeActivateInputFields()
    {
        RandomEvent.text = "";
        if (inputField_Incident != null)
        inputField_Incident.gameObject.SetActive(false);

        if(inputField_Response != null)
        inputField_Response.gameObject.SetActive(false);
        Progress.value = GameManager.instance.PlayScore;
    }

    public void ClearResponseInputFields()
    {
        RandomEvent.text = "";
        //Clears the inputfield
        inputField_Response.text = "";
        inputField_Response.Select();
        inputField_Response.ActivateInputField();
        RandomEvent.text = "";
    }

    public void ClearIncidentInputFields()
    {
        RandomEvent.text = "";
        //Clears the inputfield
        inputField_Incident.text = "";
        inputField_Incident.Select();
        inputField_Incident.ActivateInputField();
    }
}

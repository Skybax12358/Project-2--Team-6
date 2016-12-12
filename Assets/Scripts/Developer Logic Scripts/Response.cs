using UnityEngine;
using System.Collections;

public class Response : MonoBehaviour {
    //Used to match the playing input to the response card
    public string ID;
    //Used to match the response card to the video clip
    public string VideoID;
    //Score that is applied when this card is played.
    public float inc1_points;
    public float inc2_points;
    public float inc3_points;
    public float inc4_points;
    public float inc5_points;
    public float inc6_points;
    public float inc7_points;
    public float inc8_points;
    public float inc9_points;
    public float inc10_points;

    //If your response cards have effects, put them here
    public void Activate()
    {
        if (GamePlayManager.instance.IncidentNumber == 1)
        {
            VideoID = "1-" + ID;
            GameManager.instance.PlayScore += inc1_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 2)
        {
            VideoID = "2-" + ID;
            GameManager.instance.PlayScore += inc2_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 3)
        {
            VideoID = "3-" + ID;
            GameManager.instance.PlayScore += inc3_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 4)
        {
            VideoID = "4-" + ID;
            GameManager.instance.PlayScore += inc4_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 5)
        {
            VideoID = "5-" + ID;
            GameManager.instance.PlayScore += inc5_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 6)
        {
            VideoID = "6-" + ID;
            GameManager.instance.PlayScore += inc6_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 7)
        {
            VideoID = "7-" + ID;
            GameManager.instance.PlayScore += inc7_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 8)
        {
            VideoID = "8-" + ID;
            GameManager.instance.PlayScore += inc8_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 9)
        {
            VideoID = "9-" + ID;
            GameManager.instance.PlayScore += inc9_points;
        }

        else if (GamePlayManager.instance.IncidentNumber == 10)
        {
            VideoID = "10-" + ID;
            GameManager.instance.PlayScore += inc10_points;
        }
    }
}

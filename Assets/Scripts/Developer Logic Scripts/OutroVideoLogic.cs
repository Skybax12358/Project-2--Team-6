using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutroVideoLogic : MonoBehaviour {

    [SerializeField]
    VideoController videoController;
    [SerializeField]
    UIController uiController;

	// Use this for initialization
	void Start ()
    {
        videoController.PlayVideo(DetermineOutroVideo(videoController.videoClips));
	}


    VideoClip DetermineOutroVideo(List<VideoClip> _videoClips)
    {
        //Checks if the players score is above zero and chooses one of the clips based on that.
        if(GameManager.instance.PlayScore > 25)
        {
            uiController.RandomEvent.text = "You Win!";
            return _videoClips[0];
        }
        else if (GameManager.instance.PlayScore < 25)
        {
            uiController.RandomEvent.text = "You Lose!";
            return _videoClips[1];
        }

        return _videoClips[1];
    }
	
}

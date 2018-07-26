using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
//using UnityEngine.Video;

public class PlayPauseReset : MonoBehaviour {
    //Used for UI Buttons
    public PlayableDirector timeline;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		timeline.Play ();
        return;
	}
	public void Pause(){
        timeline.Pause ();
        return;
	}
	public void Reset(){
        timeline.Stop ();
        return;
	}

}

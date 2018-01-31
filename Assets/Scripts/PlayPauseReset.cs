using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Playables;

public class PlayPauseReset : MonoBehaviour {

	private VideoPlayer videoPlayer;
	public GameObject TV;
	public PlayableDirector agentTimeline;

	// Use this for initialization
	void Start () {
		videoPlayer = GetComponent<VideoPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Play(){
		videoPlayer.Play ();
		agentTimeline.Play ();
	}
	public void Pause(){
		videoPlayer.Pause ();
		agentTimeline.Pause ();
	}
	public void Reset(){
		videoPlayer.Stop ();
		agentTimeline.Stop ();
	}
	public void OnOffSwitch(){
		if (!TV.activeSelf)
			TV.SetActive (true);
		else
			TV.SetActive (false);
		
	}

}

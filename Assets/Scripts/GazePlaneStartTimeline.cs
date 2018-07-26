using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
//using UnityEngine.Video;

public class GazePlaneStartTimeline : MonoBehaviour {
    //Interactive SloMo Event
	public PlayableDirector agentTimeline;
 	public GameObject firstAgent;

    private AudioSource gazeAudio;
    public AudioClip slowmoIn;
    public AudioClip slomoOut;

    private bool HasToStop;
 	private bool IsGazedAt;

	// Use this for initialization
	void Start () {
		SetGazedAt(false);
		HasToStop = true;

		IsGazedAt = false;

        gazeAudio = GetComponent<AudioSource>();
    }
	
    //Sets IsGazedAt bool fpr interaction
	public void SetGazedAt(bool gazedAt) {
		IsGazedAt = gazedAt ? true : false;
		    //if (inactiveMaterial != null && gazedAtMaterial != null)  {
		     	//GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
		      return;
		    //}
		    //GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  	}

	// Update is called once per frame
	void Update () {
        //Pause as soon as first Agent appears and play SloMo Audio
		if (firstAgent.activeSelf && HasToStop == true){
            agentTimeline.Pause();
            gazeAudio.PlayOneShot(slowmoIn, 0.5F);
            Time.timeScale = 0.5F;
			HasToStop = false;
			} 
        //resume
		if (HasToStop == false && IsGazedAt == true){
			agentTimeline.Play ();
            gazeAudio.PlayOneShot(slomoOut, 0.5F);
            Time.timeScale = 1.0F;
        }

	}
}

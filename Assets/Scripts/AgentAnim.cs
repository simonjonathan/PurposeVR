using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnim : MonoBehaviour {

	private Animator anim;

	public float agent_velocity;
	public Vector3 agent_previous;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        //Update Agent velocity for animator
        agent_velocity = ((transform.position - agent_previous).magnitude) / Time.deltaTime;
        anim.SetFloat ("Velocity", Mathf.Abs(agent_velocity));
		agent_previous = transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour {

    public bool handsToFist;

    public GameObject openHands;
    public GameObject fistHands;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (handsToFist == false)
        {
            openHands.SetActive(true);
            fistHands.SetActive(false);
        }
        else
        {
            openHands.SetActive(false);
            fistHands.SetActive(true);
        }
	}
}

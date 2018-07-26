using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentMovement : MonoBehaviour {
    // Game Agent Controller
    GameObject player;
    HandsController playerHands;

    NavMeshAgent nav;

    public Vector3 camDirection;
    GameObject mainCamera;
    GameObject gameManagerOBJ;
    GameManager gameManager;

    AudioSource agentAudio;
    public AudioClip[] punchClips;
    int randomIndex;

    // Use this for initialization
    void Start () {
        //Set Variables manually because Agent is spawned
        player = GameObject.FindGameObjectWithTag("Player");
        playerHands = player.GetComponent <HandsController> ();
        nav = GetComponent <NavMeshAgent> ();
        agentAudio = GetComponent <AudioSource> ();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameManagerOBJ = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerOBJ.GetComponent <GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
        //Move towards Player
        if (nav.enabled == true)
        {
            nav.SetDestination(player.transform.position);
        }

	}

    void OnCollisionEnter(Collision col)
    {   
        //Collision with Player -> Game Over
        if (col.gameObject.name == "Player")
        {
            gameManager.collisionWithPlayer = true;
        }
    }

    public void SetGazedAt(bool gazedAt)
    {   
        //Display Fists when looking at Agent
        playerHands.handsToFist = gazedAt;
        return;
    }

    public void DefeatAgent() {
        nav.enabled = false;
        //Play random Punch Sound
        randomIndex = Random.Range(0, punchClips.Length);
        agentAudio.PlayOneShot(punchClips[randomIndex]);
        //Add Force to Agent in direction Player is looking
        camDirection = mainCamera.transform.forward;
        GetComponent<Rigidbody>().AddForce(camDirection * 200, ForceMode.Impulse);
        //Add Score
        gameManager.gameScore += 100;
        //Despawn agent after 3 seconds
        Destroy(this.gameObject, 3);
    }

}

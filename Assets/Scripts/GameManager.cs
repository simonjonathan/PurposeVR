using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public PlayableDirector agentTimeline;
    public int defeatedAgents;
    public GameObject tutorialDisplay;
    public bool deactivatedDisplay;
    public GameObject[] agents;

    public int gameScore;
    public bool gameMode;
    public GameObject gameAgent;
    public float spawnTime = 1.5f;
    public Transform[] spawnPoints;
    public bool collisionWithPlayer;

    public Text scoreDisplay;
    public AudioSource gameSoundSource;
    public AudioClip fightMusic;
    public AudioClip ambientMusic;

    // Use this for initialization
    void Start () {
        agentTimeline.stopped += OnPlayableDirectorStopped;
        deactivatedDisplay = false;
        gameMode = false;

    }
	
	// Update is called once per frame
	void Update () {
        //When All Timeline Agents are defeated -> remove Agents, start Music
        if (defeatedAgents > 7 && deactivatedDisplay == false)
        {
            tutorialDisplay.SetActive(false);
            deactivatedDisplay = true;
            DestroyAgents();
            gameSoundSource.clip = fightMusic;
            gameSoundSource.Play();
        }
        //Collision ->  Game Over, Display Score (Set from Game Agent)
        if(collisionWithPlayer == true)
        {
            CancelInvoke();
            scoreDisplay.enabled = true;
            scoreDisplay.text = "Score: " + gameScore;
            gameSoundSource.clip = ambientMusic;
            gameSoundSource.Play();
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {   
        //When Timeline is finished, enable Tutorial Text
        if (agentTimeline == aDirector)
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");

        tutorialDisplay.SetActive(true);
        deactivatedDisplay = false;
    }

    void DestroyAgents()
    {   
        //Destroy Timeline Agents and Start Spawning Game Agents
        for (int i = 0; i < 8; i++)
        {
            Destroy(agents[i], 3);
        }
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {   
        //Spawn Game Agents at random Spawn Points
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(gameAgent, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}

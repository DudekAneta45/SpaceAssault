using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    ScoreBoard scoreBoard;

    public static int lapsNumber = 0;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ignore")
        {
            lapsNumber++;
            ReturnLapsNumber();
        }
        else
        {
            StartDeathSequence();
            deathFX.SetActive(true);
            Invoke("ReloadScene", levelLoadDelay);
            lapsNumber = 0;
            scoreBoard.ResetScore();

        }
    }

    public int ReturnLapsNumber()
    {
        return lapsNumber;
    }

    public void ResetLapsNumber()
    {
        lapsNumber = 0;
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath"); // Send message to other scripts on the same game object (Player ship)
    }

    private void ReloadScene() //string reference
    {
        SceneManager.LoadScene(0);
    }
}

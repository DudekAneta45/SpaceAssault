using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    ScoreBoard scoreBoard;
    CollisionHandler collisionHandler;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        collisionHandler = FindObjectOfType<CollisionHandler>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
        scoreBoard.ResetScore();
        collisionHandler.ResetLapsNumber();
    }

    public void LoadEndScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

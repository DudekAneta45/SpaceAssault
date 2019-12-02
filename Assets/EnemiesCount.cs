using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCount : MonoBehaviour {

    public int enemiesNumber;
    SceneLoader sceneLoader;

    [SerializeField] GameObject endCanvas;

	// Use this for initialization
	void Start ()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        GameObject[] enemiesToFind = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesNumber = enemiesToFind.Length;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(enemiesNumber<1)
        {
            Invoke("LoadEndScreen", 1.5f);
        }
    }

    private void LoadEndScreen()
    {
        sceneLoader.LoadEndScreen();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapsBoard : MonoBehaviour {

    CollisionHandler collisionHandler;

    Text scoreText;

    // Use this for initialization
    void Start ()
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
        scoreText = GetComponent<Text>();
    }
    private void Update()
    {
        scoreText.text = collisionHandler.ReturnLapsNumber().ToString();
    }


}

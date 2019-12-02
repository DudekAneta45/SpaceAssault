﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public static int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    public void ScoreHit(int scoreHit)
    {
        score = score + scoreHit;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }

}

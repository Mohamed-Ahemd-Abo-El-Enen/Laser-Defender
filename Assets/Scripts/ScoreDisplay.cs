﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score;
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
    }

    private void OnPlayerFuelPickup()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    GameObject _gameOverText;
    private void Start()
    {
        _gameOverText = GameObject.Find("GameOverText");
        GameEvents.Current.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        _gameOverText.transform.position = new Vector2(0, 0);
    }
}

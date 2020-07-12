using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedBehavior : MonoBehaviour
{
    private bool paused = false;
    private UnityEngine.UI.Text pauseText;
    private bool gameOver = false;

    private void Start()
    {
        pauseText = GameObject.Find("PausedText").GetComponent<UnityEngine.UI.Text>();
        pauseText.color = new Color(1f, 1f, 1f, 0f);
        GameEvents.Current.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        gameOver = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            GameEvents.Current.Pause();
            paused = !paused;

            if (paused)
            {
                pauseText.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                pauseText.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindowBehavior : MonoBehaviour
{
    private Button retryButton;
    private Button quitButton;
    private void Awake()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();        
        retryButton.onClick.AddListener(Retry);
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(QuitToMainMenu);
    }

    private void Start()
    {
        gameObject.SetActive(true);
        GameEvents.Current.OnGameOver += OnGameOver;
        gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        gameObject.SetActive(true);
        retryButton.Select();
    }

    private void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void QuitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

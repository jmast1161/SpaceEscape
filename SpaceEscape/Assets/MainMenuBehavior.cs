using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    private Button playButton;
    private Button quitButton;

    // Start is called before the first frame update
    private void Start()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(Play);
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(Quit);

        playButton.Select();
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusicBehavior>().StopMusic();
    }

    private void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Quit()
    {
        Application.Quit();
    }
}

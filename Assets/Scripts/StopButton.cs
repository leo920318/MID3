using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public Button PauseButton;
    public GameObject PauseWindow;
    public GameObject QuitButton;
    public GameObject VoiceControl;
    private bool isPause;
    void Start()
    {
        isPause = false;
        PauseButton.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PauseGame()
    {
        isPause = !isPause;
        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            VoiceControl.gameObject.SetActive(true);
            QuitButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseWindow.gameObject.SetActive(false);
            VoiceControl.gameObject.SetActive(false);
            QuitButton.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

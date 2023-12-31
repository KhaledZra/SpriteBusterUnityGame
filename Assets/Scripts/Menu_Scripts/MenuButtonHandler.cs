using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button unlocksButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;
    void Start()
    {
        // Since some buttons can be null (Script is shared between menu scenes)
        if (startButton != null)
        {
            startButton.onClick.AddListener(TaskOnClickStartGame);
        }
        if (unlocksButton != null)
        {
            unlocksButton.onClick.AddListener(TaskOnClickUnlocks);
        }
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(TaskOnClickMainMenu);
        }
        if (tutorialButton != null)
        {
            tutorialButton.onClick.AddListener(TaskOnClickStartTutorial);
        }
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(TaskOnClickQuitGame);
        }
    }

    void TaskOnClickStartGame()
    {
        SceneManager.LoadScene("Scenes/PlayScene");
    }
    
    void TaskOnClickUnlocks()
    {
        SceneManager.LoadScene("Scenes/UnlockScene");
    }
    
    void TaskOnClickMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    private void TaskOnClickStartTutorial()
    {
        SceneManager.LoadScene("Scenes/TutorialScene");
    }
    
    void TaskOnClickQuitGame()
    {
        Application.Quit();
    }
}

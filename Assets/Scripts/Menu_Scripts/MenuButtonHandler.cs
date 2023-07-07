using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;
    void Start()
    {
        startButton.onClick.AddListener(TaskOnClickStartGame);
        quitButton.onClick.AddListener(TaskOnClickQuitGame);
        if (mainMenuButton != null) // indicates script being used by lose menu
        {
            mainMenuButton.onClick.AddListener(TaskOnClickMainMenu);
        }
        else // indicates script being used by main menu
        {
            // shopButton.onClick.AddListener(TaskOnClickStartGame);
            // tutorialButton.onClick.AddListener(TaskOnClickStartGame);
        }
    }
    void TaskOnClickStartGame()
    {
        SceneManager.LoadScene("Scenes/PlayScene");
    }
    
    void TaskOnClickQuitGame()
    {
        // todo save game data
        
        // todo for debug
        //UnityEditor.EditorApplication.isPlaying = false;
        
        // todo ship with this one:
        Application.Quit();
    }
    
    void TaskOnClickMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}

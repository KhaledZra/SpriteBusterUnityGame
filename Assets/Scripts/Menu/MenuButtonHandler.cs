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
    void Start()
    {
        startButton.onClick.AddListener(TaskOnClickStartGame);
        // shopButton.onClick.AddListener(TaskOnClickStartGame);
        // tutorialButton.onClick.AddListener(TaskOnClickStartGame);
        quitButton.onClick.AddListener(TaskOnClickQuitGame);
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
}

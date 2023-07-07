using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameHandler : MonoBehaviour
{
    private bool _isGamePaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (!_isGamePaused)
            {
                Time.timeScale = 0;
                _isGamePaused = true;
            }
            else
            {
                Time.timeScale = 1;
                _isGamePaused = false;
            }
        }
    }
}

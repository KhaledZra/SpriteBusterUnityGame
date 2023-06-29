using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float _time = 0.0f;
    private int _seconds = 0;
    private int _minutes = 0;
    private TextMeshProUGUI timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1.0f)
        {
            _seconds++;
            _time -= 1.0f;
            timerText.text = _minutes + ":" + _seconds;
        }

        if (_seconds >= 60)
        {
            _minutes++;
            timerText.text = _minutes + ":" + _seconds;
        }
    }
}

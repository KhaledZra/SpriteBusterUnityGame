using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    // todo change private and add _
    [SerializeField] private DifficultyScaler difficultyScaler;
    
    private float _time = 0.0f;
    private int _seconds = 0;
    private int _minutes = 0;
    private TextMeshProUGUI timerText;

    private EnemyHandler v;
    private HealthHandler b;
    
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
            _seconds = 0;
            timerText.text = _minutes + ":" + _seconds;
            difficultyScaler.ApplyDifficultyModifier(_minutes);
        }
    }
}

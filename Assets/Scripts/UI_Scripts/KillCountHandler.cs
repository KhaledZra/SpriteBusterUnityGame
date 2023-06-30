using System;
using TMPro;
using UnityEngine;

public class KillCountHandler : MonoBehaviour
{
    private int _killCount = 0;
    private TextMeshProUGUI _killCountText;

    private void Start()
    {
        _killCountText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void AddKill()
    {
        _killCount++;
        _killCountText.text = "Kills: " + _killCount;
    }
}

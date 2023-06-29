using System;
using TMPro;
using UnityEngine;

public class UpdateKillCounter : MonoBehaviour
{
    public void AddKill()
    {
        var killCountText = gameObject.GetComponent<TextMeshProUGUI>();
        int killCountInInt = Convert.ToInt32(killCountText.text);
        killCountInInt++;
        killCountText.text = killCountInInt.ToString();
    }
}

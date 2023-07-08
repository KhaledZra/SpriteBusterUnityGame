using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlocksMenuHandler : MonoBehaviour
{
    [SerializeField] private JsonPlayerDataHandler playerDataHandler;
    [SerializeField] private TextMeshProUGUI shotgunText;
    [SerializeField] private TextMeshProUGUI rifleText;
    [SerializeField] private TextMeshProUGUI minigunText;
    [SerializeField] private TextMeshProUGUI statsText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData playerData = playerDataHandler.LoadPlayerDataFromJson();
        
        if (playerData.isShotgunUnlocked)
        {
            shotgunText.text = "Unlocked";
            shotgunText.color = Color.green;
        }
        
        if (playerData.isRifleUnlocked)
        {
            rifleText.text = "Unlocked";
            rifleText.color = Color.green;
        }
        
        if (playerData.isMinigunUnlocked)
        {
            minigunText.text = "Unlocked";
            minigunText.color = Color.green;
        }

        statsText.text = $"Kill record: {playerData.killRecord} | Total kills: {playerData.totalKills}";
    }
}

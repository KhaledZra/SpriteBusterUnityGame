using System;
using System.IO;
using UnityEngine;

public class JsonPlayerDataHandler : MonoBehaviour
{
    private string _filePath;

    private void Start()
    {
        _filePath = Application.dataPath + "/PlayerDataFile.json";
    }

    public void SavePlayerDataToJson(int currentKillAttempt)
    {
        PlayerData playerData = LoadPlayerDataFromJson();
        playerData.SetIfKillRecord(currentKillAttempt);
        playerData.totalKills += currentKillAttempt;

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(_filePath, json);
    }
    
    public PlayerData LoadPlayerDataFromJson()
    {
        if (!File.Exists(_filePath))
        {
            return new PlayerData();
        }
        
        string json = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}

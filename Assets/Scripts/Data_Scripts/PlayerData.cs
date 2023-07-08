[System.Serializable]
public class PlayerData
{
    public int totalKills = 0;
    public int killRecord = 0;

    public bool isShotgunUnlocked = false;
    public bool isRifleUnlocked = false;
    public bool isMinigunUnlocked = false;
    
    public void SetIfKillRecord(int currentAttempt)
    {
        if (currentAttempt > killRecord)
        {
            killRecord = currentAttempt;
            CheckUnlocks();
        }
    }
    
    private void CheckUnlocks()
    {
        if (isShotgunUnlocked == false)
        {
            if (killRecord >= 100)
            {
                isShotgunUnlocked = true;
            }
        }
        
        if (isRifleUnlocked == false)
        {
            if (killRecord >= 250)
            {
                isShotgunUnlocked = true;
            }
        }
        
        if (isMinigunUnlocked == false)
        {
            if (killRecord >= 500)
            {
                isShotgunUnlocked = true;
            }
        }
    }
}
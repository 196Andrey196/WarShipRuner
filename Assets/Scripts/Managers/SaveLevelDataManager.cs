using UnityEngine;

public class SaveLevelDataManager : MonoBehaviour
{
    public static SaveLevelDataManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public void SaveData(PlayerData playerData)
    {
        PlayerPrefs.SetInt("CurrentLevelId", playerData.currentLevelId);
        PlayerPrefs.SetFloat("CoinsInWallet", playerData.currentCoinsInWallet);
    }
    public void LoadData(PlayerData playerData)
    {
        playerData.currentLevelId = PlayerPrefs.GetInt("CurrentLevelId", 0);
        playerData.currentCoinsInWallet = PlayerPrefs.GetFloat("CoinsInWallet", 1000);
    }

}

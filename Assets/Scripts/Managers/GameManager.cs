using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;
     [SerializeField] private GameObject _player;
     private PlayerData _playerData;
     [SerializeField] private bool _gameStarted;
     public bool pauseStatus;
     [SerializeField] private GameObject _gameOverMenu;
     [SerializeField] private GameObject _winMenu;
   

     private void Awake()
     {
          if (instance != null)
          {
               return;
          }
          instance = this;
     }
     private void Start()
     {
          SetStartSettings();
          _gameStarted = true;
          SetPauseStatus();
          SwipeManager.instance.playerSwipe += PlayerSwipe;
     }
     private void OnDisable()
     {
          SwipeManager.instance.playerSwipe -= PlayerSwipe;
     }

     private void PlayerSwipe()
     {
          if (pauseStatus)
          {
               SetPauseStatus();
          }
     }

     private void Update()
     {
          if (_playerData.currentHealth == 0) GameOver();
     }
     private void GameOver()
     {
          if (_gameOverMenu)
          {
               _gameOverMenu.SetActive(true);
          }
     }
     public void LevelComplete()
     {
        
          SaveLevelDataManager.instance.SaveData(_playerData);
          _player.transform.GetChild(1).gameObject.SetActive(false);
          if (_winMenu) _winMenu.SetActive(true);
     }
     private void SetStartSettings()
     {
          _playerData = _player.GetComponent<PlayerData>();
          SaveLevelDataManager.instance.LoadData(_playerData);
          Wallet.instance.UpdateCoinsCounter();
     }
     public void SetPauseStatus()
     {
          if (_gameStarted)
          {
               Time.timeScale = 0;
               _gameStarted = false;
          }
          else
          {
               Time.timeScale = 1;
               _gameStarted = true;
               pauseStatus = false;
          }
     }

}

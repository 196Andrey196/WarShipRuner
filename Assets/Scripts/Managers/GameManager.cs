using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject _player;
   private MainObjectData _playerData;
   private void Start() {
    _playerData = _player.GetComponent<MainObjectData>();
   }
   private void Update() {
        if(_playerData.currentHealth == 0)GameOver();
   }

    private void GameOver()
    {
      
    }
}

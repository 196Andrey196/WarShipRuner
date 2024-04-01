using System;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
  [SerializeField] private GameObject _startMenu;
  [SerializeField] private GameObject _startInfo;
  private Button _upgradeBTN;
  private Button _playBTN;
  private void Start()
  {
    _upgradeBTN = _startMenu.transform.GetChild(1).GetComponent<Button>();
    _playBTN = _startMenu.transform.GetChild(2).GetComponent<Button>();
    _upgradeBTN.onClick.AddListener(UpgradeButtonClick);
    _playBTN.onClick.AddListener(PlayButtonClick);
    SwipeManager.instance.playerSwipe += PlayerSwipe;
    if (UpgradeManager.instance.CheckCurrentLevel()) _upgradeBTN.interactable = false;
  }

  private void OnDisable()
  {
    SwipeManager.instance.playerSwipe -= PlayerSwipe;
  }

  private void PlayerSwipe()
  {
    if (_startInfo) _startInfo.SetActive(false);

  }


  private void UpgradeButtonClick()
  {
    UpgradeManager.instance.UpgradePlayer();
    if (UpgradeManager.instance.CheckCurrentLevel()) _upgradeBTN.interactable = false;
  }


  private void PlayButtonClick()
  {
    if (_startMenu)
    {
      GameManager.instance.pauseStatus = true;
      _startMenu.SetActive(false);
      _startInfo.SetActive(true);
    }

  }
}

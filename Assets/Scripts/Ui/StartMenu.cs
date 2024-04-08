using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
  [SerializeField] private GameObject _startMenu;
  [SerializeField] private GameObject _startInfo;
  private Button _upgradeBTN;
  private Button _playBTN;
  [SerializeField] private AudioClip _buySound;
  private void Start()
  {
    AddButtonsAndListeners();
    SwipeManager.instance.playerSwipe += PlayerSwipe;
  }
  private void AddButtonsAndListeners()
  {
    _upgradeBTN = _startMenu.transform.GetChild(1).GetComponent<Button>();
    _playBTN = _startMenu.transform.GetChild(2).GetComponent<Button>();
    _upgradeBTN.onClick.AddListener(UpgradeButtonClick);
    _playBTN.onClick.AddListener(PlayButtonClick);
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
    SoundManager.instance.PlaySoundEfects(_buySound,0.3f);
    PlayerUpgradeManager.instance.UpgradePlayer();
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

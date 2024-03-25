using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    private Button _upgradeBTN;
    private Button _playBTN;
    private void Start()
    {
        _upgradeBTN = _startMenu.transform.GetChild(1).GetComponent<Button>();
        _playBTN = _startMenu.transform.GetChild(2).GetComponent<Button>();
        _upgradeBTN.onClick.AddListener(UpgradeButtonClick);
        _playBTN.onClick.AddListener(PlayButtonClick);
    }


    private void UpgradeButtonClick()
    {
      UpgradeManager.instance.upgrade?.Invoke();

    }


    private void PlayButtonClick()
    {
       if(_startMenu)_startMenu.SetActive(false);
    }
}

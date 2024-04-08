using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private Button _retry;
    private void Start()
    {
        SoundManager.instance.PlaySoundEfects(_loseSound, 0.1f);
        SoundManager.instance.MuteMusic();
        _retry.onClick.AddListener(OnRetryButtonClick);
    }
    private void OnRetryButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}

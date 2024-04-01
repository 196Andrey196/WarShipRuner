using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Button _nextLevelBTN;
    private int sceneCount;

    private void Start()
    {
        _nextLevelBTN.onClick.AddListener(OnLevelNextButtonClick);
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    private void OnLevelNextButtonClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = (currentSceneIndex + 1) % sceneCount;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
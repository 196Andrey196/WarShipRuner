using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private AnimationCurve curve;


    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float time = 1f;
        while (time > 0f)
        {
            time -= Time.unscaledDeltaTime;
            float alfa = curve.Evaluate(time);
            img.color = new Color(0, 0, 0, alfa);
            yield return 0;
        }
    }

    IEnumerator FadeOut(int scene)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.unscaledDeltaTime;
            float alfa = curve.Evaluate(time);
            img.color = new Color(0, 0, 0, alfa);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}

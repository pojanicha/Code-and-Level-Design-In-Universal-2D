using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleFade : MonoBehaviour
{
    public static SimpleFade Instance;

    public CanvasGroup fadePanel;
    public float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        StartCoroutine(FadeIn()); // เริ่มเกมค่อยๆ เปิด
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(FadeAndLoad(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        fadePanel.alpha = 1;

        fadePanel.blocksRaycasts = true; 

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.alpha = 1 - (t / fadeDuration);
            yield return null;
        }

        fadePanel.alpha = 0;
        fadePanel.blocksRaycasts = false;
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        fadePanel.alpha = 0;

        fadePanel.blocksRaycasts = true;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.alpha = t / fadeDuration;
            yield return null;
        }

        fadePanel.alpha = 1;
    }

    IEnumerator FadeAndLoad(int sceneIndex)
    {
        yield return FadeOut();
        SceneManager.LoadScene(sceneIndex);

        yield return null; 

        yield return FadeIn();
    }






}
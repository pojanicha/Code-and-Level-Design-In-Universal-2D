using UnityEngine;
using System.Collections;

public class EndingSequence : MonoBehaviour
{
    public CanvasGroup message1;
    public CanvasGroup message2;
    public RectTransform credits;

    public float fadeDuration = 1f;
    public float stayDuration = 2f;
    public float scrollSpeed = 50f;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        // เริ่มต้นปิดทั้งหมด
        message1.alpha = 0;
        message2.alpha = 0;
        credits.gameObject.SetActive(false);

        // 🔹 ข้อความ 1
        yield return Fade(message1, 0, 1);
        yield return new WaitForSeconds(stayDuration);
        yield return Fade(message1, 1, 0);

        // 🔹 ข้อความ 2
        yield return Fade(message2, 0, 1);
        yield return new WaitForSeconds(stayDuration);
        yield return Fade(message2, 1, 0);

        // 🔹 เครดิต
        credits.gameObject.SetActive(true);
        yield return StartCoroutine(ScrollCredits());
    }

    IEnumerator Fade(CanvasGroup cg, float start, float end)
    {
        float t = 0;
        cg.alpha = start;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, t / fadeDuration);
            yield return null;
        }

        cg.alpha = end;
    }

    IEnumerator ScrollCredits()
    {
        while (true)
        {
            credits.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
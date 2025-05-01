using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{
    public float fadeDuration = 2f;
    private Image blackImage;
    private float currentTime = 0f;

    void Start()
    {
        blackImage = GetComponent<Image>();

        // Garante que a imagem começa transparente
        Color c = blackImage.color;
        c.a = 0f;
        blackImage.color = c;
    }

    // Chame este método quando quiser iniciar o fade
    public void StartFade()
    {
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(currentTime / fadeDuration);
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}

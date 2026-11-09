using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls a full-screen black overlay for fade-in / fade-out transitions
public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;   // Global access point

    [SerializeField] private Image fadeImage;   // Full-screen black Image
    [SerializeField] private float fadeDuration = 0.8f;

    private void Awake()
    {
        // Simple singleton so other scripts can call SceneFader.Instance
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Every scene starts black, then fades in automatically
        StartCoroutine(FadeIn());
    }

    // Fade from black to the current scene
    public IEnumerator FadeIn()
    {
        fadeImage.raycastTarget = true;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - (t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0f);
        fadeImage.raycastTarget = false;   // Let clicks pass through when clear
    }

    // Fade to black, then load the target scene
    public IEnumerator FadeOutAndLoad(string sceneName)
    {
        fadeImage.raycastTarget = true;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(1f);
        SceneManager.LoadScene(sceneName);
    }

    // Public shortcut so buttons can call it directly
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private void SetAlpha(float a)
    {
        Color c = fadeImage.color;
        c.a = a;
        fadeImage.color = c;
    }
}

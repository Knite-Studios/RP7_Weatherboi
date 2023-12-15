using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingSlider;
    public float fakeLoadingSpeed = 0.2f;
    private float progress = 0f;
    [SerializeField] 
    private string sceneName = "01_MainMenu";

    void Awake()
    {
        Time.timeScale = 1f;
        if(loadingSlider == null)
        {
            Debug.LogWarning("No reference to loadingSlider. Please set in the Inspector.");
            return;
        }

        StartCoroutine(FakeLoadingCoroutine());
    }

    IEnumerator FakeLoadingCoroutine()
    {
        while(progress < 1f)
        {
            progress += fakeLoadingSpeed * Time.deltaTime;
            if(loadingSlider != null)
            loadingSlider.value = progress;
            yield return null;
        }
        Debug.Log(progress);
        progress = 0f;
        SceneManager.LoadScene(sceneName);
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "03_Loading";
    [SerializeField]
    private Animator fadeAnimator; // Reference to the Animator component
    [SerializeField]
    private float fadeDuration = 0.30f; // Duration of the fade effect

    IEnumerator LoadSceneAfterFade()
    {
        fadeAnimator.SetTrigger("Start"); // Assuming "Start" is the trigger for your animation
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadSceneAfterFade());
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent(typeof(AudioSource))]
public class PauseMenu : Singleton<PauseMenu>
{
    [SerializeField]
    private GameObject pauseMenu;
    [Header("QUITING"),SerializeField]
    private string QuitTo = "03_Loading";

    private bool isMuted = false;

    AudioSource _menuSpeaker;
    private void Awake()
    {
       
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

       _menuSpeaker = GetComponent<AudioSource>();
    }
    private bool paused = false;
    void Pause()
    {
        Time.timeScale = 0;
        ToggleMute();
        pauseMenu.SetActive(true);
        paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        ToggleMute();
        pauseMenu.SetActive(false);
        paused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(QuitTo);
    }
    public void ToggleMute()
    {

        isMuted = !isMuted;
        _menuSpeaker.mute = isMuted;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.canPause)
        {
            if (!paused)
                Pause();
            else if (paused)
                Resume();
        }
    }

}

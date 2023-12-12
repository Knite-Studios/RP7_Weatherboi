using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent(typeof(AudioSource))]
public class MainMenu : Singleton<MainMenu>
{
    [SerializeField]
    private AudioClip _menuClip;
    [SerializeField]
    private GameObject _teamScreen;
    [SerializeField]
    private string sceneName = "03_Loading";
    private bool _teamScreenOn = false;

    private AudioSource _menuSpeaker;

    private void Awake()
    {

        _teamScreen.SetActive(false);

        _menuSpeaker = GetComponent<AudioSource>();
        _menuSpeaker.loop = true;
    }
    void Start()
    {
       
        PlayMainMusic();
        Cursor.visible = true;

    }
    private void PlayMainMusic()
    {
        if (_menuSpeaker != null && _menuClip != null)
        {
            _menuSpeaker.clip = _menuClip;
            _menuSpeaker.Play();
        }
    }
    public void ToggleTeamScreen()
    {
        _teamScreenOn = !_teamScreenOn;
        _teamScreen.SetActive(_teamScreenOn);
    }
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
    }
}

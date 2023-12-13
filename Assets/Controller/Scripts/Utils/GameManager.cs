using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public bool canPause = true;
    public GameObject winScreen;

    int keyscollected = 0;
    public int KeysNeeded = 3;

    public UnityEvent OpenExit;
    bool isOpen = false;
    AudioSource _menuSpeaker;
    [SerializeField]
    AudioClip keySound;
    [SerializeField]
    AudioClip GameMusic;
    void Start()
    {
        _menuSpeaker = GetComponent<AudioSource>();
        winScreen.SetActive(false);
        _menuSpeaker.clip = GameMusic;
        _menuSpeaker.loop = true;
        _menuSpeaker.Play();
    }
    public void CollectedKey()
    {
        keyscollected++;
        _menuSpeaker.PlayOneShot(keySound);


    }
    void CheckKeys()
    {
        if ((keyscollected == KeysNeeded || Input.GetKeyDown(KeyCode.P)) && !isOpen)
        {
            isOpen = true;
            OpenExit.Invoke();

        }
    }
    void Update()
    {
        CheckKeys();
    }
    public void Win()
    {
        Debug.Log("You Win!");
        PauseMenu.Instance.Pause();
        winScreen.SetActive(true);
    }
}

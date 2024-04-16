using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    static MusicManager instance;

    [SerializeField] AudioClip mainMenu;
    [SerializeField] AudioClip underground;
    [SerializeField] AudioClip runGin;
    [SerializeField] AudioClip behindDoors;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip theEnd;

    AudioSource source;
    float policeCue;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            this.transform.parent = null;
            DontDestroyOnLoad(gameObject);

            source = GetComponent<AudioSource>();
            policeCue = 0;
        }
    }

    public static MusicManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string title)
    {
        switch(title)
        {
            case "Main Menu":
                source.clip = mainMenu;
                source.Play();
                break;
            case "Underground":
                source.clip = underground;
                source.Play();
                break;
            case "Run n Gin":
                source.clip = runGin;
                source.Play();
                break;
            case "Game Over":
                source.clip = gameOver;
                source.Play();
                break;
            case "The End":
                source.clip = theEnd;
                source.Play();
                break;
        }
    }

    public void CuePolice()
    {
        policeCue += 1;
        Debug.Log(policeCue);
        if (policeCue == 3 && SceneManager.GetActiveScene().name == "Day2Bar")
        {
            source.clip = behindDoors;
            source.Play();
        }
    }

    public void resetPoliceCue()
    {
        policeCue = 0;
    }
}

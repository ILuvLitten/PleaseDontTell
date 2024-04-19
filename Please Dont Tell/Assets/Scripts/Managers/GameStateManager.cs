using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    static GameStateManager instance;
    [SerializeField] Animator transition;

    static bool startDayOne = true;
    static bool startDayTwo = true;
    static bool startDayThree = true;
    static bool startCellar = true;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static GameStateManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

        transition = GameObject.Find("Transition").GetComponent<Animator>();
        if (transition != null) transition.Play("TransitionEndAnim");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetDayBool(float sceneNum)
    {
        switch(sceneNum)
        {
            case 1:
                return startDayOne;
                break;
            case 2:
                return startDayTwo;
                break;
            case 3:
                return startDayThree;
                break;
            case 4:
                return startCellar;
                break;
        }
        return false;
    }

    public void SetDayBool(float sceneNum, bool value)
    {
        switch(sceneNum)
        {
            case 1f:
                startDayOne = value;
                break;
            case 2f:
                startDayTwo = value;
                break;
            case 3f:
                startDayThree = value;
                break;
            case 4f:
                startCellar = value;
                break;
        }
    }

    public void Restart()
    {
        startDayOne = true;
        startDayTwo = true;
        startDayThree = true;
        startCellar = true;
    }

}

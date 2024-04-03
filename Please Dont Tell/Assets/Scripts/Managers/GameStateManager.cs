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
    static bool startDayOneCellar = true;
    static bool startDayTwoCellar = true;
    static bool startDayThreeCellar = true;

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
                return startDayOneCellar;
                break;
            case 3:
                return startDayTwo;
                break;
            case 4:
                return startDayTwoCellar;
                break;
            case 5:
                return startDayThree;
                break;
            case 6:
                return startDayThreeCellar;
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
                startDayOneCellar = value;
                break;
            case 3f:
                startDayTwo = value;
                break;
            case 4f:
                startDayTwoCellar = value;
                break;
            case 5f:
                startDayThree = value;
                break;
            case 6f:
                startDayThreeCellar = value;
                break;
        }
    }

}

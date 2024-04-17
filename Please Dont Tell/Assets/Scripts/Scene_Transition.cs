using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scene_Transition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void changePlay()
    {
        SceneManager.LoadScene("BarScene");
    }

    public void changeHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    

    public void gameOverToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void finishtoHome()
    {
        SceneManager.LoadScene("HomeScene");
    }


    public void tutorialToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void PlayMenu()
    {
        MusicManager.GetInstance().Play("Main Menu");
    }
}

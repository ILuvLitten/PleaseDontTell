using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scene_Transition : MonoBehaviour
{

    [SerializeField] Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallChange(string coroutine)
    {
        StartCoroutine(coroutine);
    }

    public IEnumerator changeTutorial()
    {
        transition.Play("TransitionStartAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TutorialScene");
    }

    public IEnumerator changePlay()
    {
        transition.Play("TransitionStartAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Day1Bar");
    }

    public IEnumerator changeHome()
    {
        transition.Play("TransitionStartAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("HomeScene");
    }

    public IEnumerator changeCredit()
    {
        transition.Play("TransitionStartAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CreditScene");
    }

    public void PlayMenu()
    {
        MusicManager.GetInstance().Play("Main Menu");
        GameStateManager.GetInstance().Restart();
    }

}

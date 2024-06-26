using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    GameObject topDoor;
    GameObject bottomDoor;

    [SerializeField] string nextScene;
    [SerializeField] float sceneNum;

    [SerializeField] Animator transition;

    bool playerIsNear;

    // Start is called before the first frame update
    void Start()
    {

        topDoor = transform.GetChild(0).gameObject;
        bottomDoor = transform.GetChild(1).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

        topDoor.SetActive(!playerIsNear);
        bottomDoor.SetActive(!playerIsNear);

        if (playerIsNear && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("door entered");
            StartCoroutine(Load());
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null) playerIsNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null) playerIsNear = false;
    }

    IEnumerator Load()
    {
        transition.Play("TransitionStartAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
        GameStateManager.GetInstance().SetDayBool(sceneNum, false);
    }
}

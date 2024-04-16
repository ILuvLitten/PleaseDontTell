using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceButton : MonoBehaviour
{

    public int idx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) &&  EventSystem.current.currentSelectedGameObject == gameObject)
        {
            DialogueManager.GetInstance().MakeChoice(idx);
        }
    }

}

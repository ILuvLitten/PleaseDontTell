using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{

    [SerializeField] TextAsset cutsceneJSON;
    public float currentDay;
    bool occured;

    [SerializeField] bool isPoliceEncounter;
    [SerializeField] NPCController npc1;
    [SerializeField] NPCController npc2;
    [SerializeField] NPCController npc3;
    [SerializeField] GameObject police;
    [SerializeField] Door door;

    // Start is called before the first frame update
    void Start()
    {
        if (GameStateManager.GetInstance().GetDayBool(currentDay))
        {
            occured = false;
        }
        else occured = true;
        if (isPoliceEncounter) {
            police.SetActive(false); 
            occured = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPoliceEncounter)
        {
            //Debug.Log("1");
            if((npc1.isServed || npc1.hasLeft) && (npc2.isServed || npc2.hasLeft) && (npc3.isServed || npc3.hasLeft))
            {
                //Debug.Log("2");
                police.SetActive(true);
                //if (door != null) Destroy(door);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((!isPoliceEncounter && other.gameObject.GetComponent<PlayerController>() != null && occured == false) || (isPoliceEncounter && police.activeSelf && occured == false))
        {
            DialogueManager.GetInstance().EnterDialogueMode(cutsceneJSON, true);
            occured = true;
        }
    }

}

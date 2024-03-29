using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;
    [SerializeField] TextAsset inkJSONserved;

    [SerializeField] bool isCustomer;
    public int ID;
    public int drinkID;
    public float sceneNum;

    [SerializeField] Sprite patience1;
    [SerializeField] Sprite patience2;
    [SerializeField] Sprite patience3;
    [SerializeField] Sprite patience4;

    GameObject patienceSprite;

    bool hasOrdered;
    bool isServed;
    bool hasLeft;

    // Start is called before the first frame update
    void Start()
    {

        patienceSprite = transform.GetChild(0).gameObject;
        patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;
        
        if (GameStateManager.GetInstance().GetDayBool(sceneNum))
        {
            StartDay();
        }
        else
        {
            NotStartDay();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateDialogue(int[] inventory)
    {
        if (isCustomer)
        {
            if (!hasOrdered)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                patienceSprite.SetActive(true);
                hasOrdered = true;
                NPCManager.GetInstance().SetHasOrdered(ID, true);
            }
            else if (inventory[drinkID] > 0 && !isServed) 
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSONserved);
                patienceSprite.SetActive(false);
                inventory[drinkID] -= 1;
                LiquorCount.GetInstance().UpdateCount(inventory);
                isServed = true;
                NPCManager.GetInstance().SetIsServed(ID, true);
            }
        }
        else if (!isCustomer) DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    public void Leave()
    {
        hasLeft = true;
        Debug.Log("patron " + ID + " has left");
    }

    /*public void SetPatienceSprite(int patience)
    {

        switch(patience)
        {
            case 1:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;
                break;
        }

    }*/

    void StartDay()
    {
        patienceSprite.SetActive(false);
        NPCManager.GetInstance().SetHasOrdered(ID, false);
        NPCManager.GetInstance().SetIsServed(ID, false);
        NPCManager.GetInstance().SetHasLeft(ID, false);
    }

    void NotStartDay()
    {
        hasOrdered = NPCManager.GetInstance().GetHasOrdered(ID);
        isServed = NPCManager.GetInstance().GetIsServed(ID);
        hasLeft = NPCManager.GetInstance().GetHasLeft(ID);
        patienceSprite.SetActive(hasOrdered);
    }
}

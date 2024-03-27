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
        patienceSprite.SetActive(false);
        hasOrdered = NPCManager.GetInstance().GetHasOrdered(ID);
        isServed = NPCManager.GetInstance().GetIsServed(ID);
        hasLeft = NPCManager.GetInstance().GetHasLeft(ID);
        if (hasLeft) Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateDialogue(int[] inventory)
    {
        if (isCustomer && !isServed)
        {
            if (!patienceSprite.activeSelf)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                patienceSprite.SetActive(true);
            }
            else if (inventory[drinkID] > 0) 
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSONserved);
                patienceSprite.SetActive(false);
                inventory[drinkID] -= 1;
                LiquorCount.GetInstance().UpdateCount(inventory);
                isServed = true;
                //inventory[itemID] -= 1;
            }
        }
        else if (!isCustomer) DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    public void Leave()
    {
        hasLeft = true;
        Debug.Log("patron " + ID + " has left");
    }

    public void SetPatienceSprite(int patience)
    {

        switch(patience)
        {
            case 1:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;
                break;
        }

    }
}

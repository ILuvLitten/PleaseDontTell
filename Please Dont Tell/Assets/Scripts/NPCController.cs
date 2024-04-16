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

    Vector3 initialScale;
    Vector3 flippedScale;

    [SerializeField] Sprite patience1;
    [SerializeField] Sprite patience2;
    [SerializeField] Sprite patience3;
    [SerializeField] Sprite patience4;

    GameObject patienceSprite;

    public bool hasOrdered;
    public bool isServed;
    public bool hasLeft;

    // Start is called before the first frame update
    void Start()
    {

        patienceSprite = transform.GetChild(0).gameObject;
        //patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;

        initialScale = transform.localScale;
        flippedScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);
        
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
        if (((isServed && !DialogueManager.GetInstance().dialogueIsPlaying) || hasLeft) && transform.position.y < 100)
        {
            Leave();
            MusicManager.GetInstance().CuePolice();
        }
        //Debug.Log(hasLeft);
    }

    public void InitiateDialogue(int[] inventory)
    {
        
        
        if (!hasOrdered)
        {
            Debug.Log("first");
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false);
            patienceSprite.SetActive(true);
            hasOrdered = true;
            NPCManager.GetInstance().SetHasOrdered(ID, true);
            TimerManager.AddTimer(gameObject);
        }
        else if (inventory[drinkID] > 0 && !isServed) 
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSONserved, false);
            patienceSprite.SetActive(false);
            inventory[drinkID] -= 1;
            LiquorCount.GetInstance().UpdateCount(inventory);
            isServed = true;
            NPCManager.GetInstance().SetIsServed(ID, true);
        }
        else return;

        if (GameObject.Find("Player") == null) return;
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        if (playerPosition.x > transform.position.x) 
        {
            transform.localScale = initialScale;;
        }
        if (playerPosition.x < transform.position.x) 
        {
            transform.localScale = flippedScale;
        }
    }

    public void Leave()
    {
        transform.position = new Vector3(transform.position.x, 100, transform.position.z);
    }

    public void SetPatienceSprite(int patience)
    {

        if (patienceSprite == null) return;

        switch(patience)
        {
            case 1:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;
                break;
            case 2:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience2;
                break;
            case 3:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience3;
                break;
            case 4:
                patienceSprite.GetComponent<SpriteRenderer>().sprite = patience4;
                hasLeft = true;
                NPCManager.GetInstance().SetHasLeft(ID, true);
                break;
        }

    }

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
        patienceSprite.SetActive(hasOrdered && !isServed);

        if (isServed || hasLeft) Leave();
    }
}

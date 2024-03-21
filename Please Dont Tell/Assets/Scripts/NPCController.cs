using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;

    [SerializeField] bool isCustomer;
    [SerializeField] int itemID;

    [SerializeField] Sprite patience1;
    [SerializeField] Sprite patience2;
    [SerializeField] Sprite patience3;
    [SerializeField] Sprite patience4;

    GameObject patienceSprite;

    // Start is called before the first frame update
    void Start()
    {

        patienceSprite = transform.GetChild(0).gameObject;
        patienceSprite.GetComponent<SpriteRenderer>().sprite = patience1;
        patienceSprite.SetActive(isCustomer);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateDialogue(int[] inventory)
    {
        if (isCustomer && inventory[itemID] <= 0) return;
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        patienceSprite.SetActive(false);
    }
}

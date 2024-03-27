using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquorCollectible : MonoBehaviour
{

    
    public int itemID;
    public int drinkID;

    public float sceneNum;

    // Start is called before the first frame update
    void Start()
    {
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

    void StartDay()
    {
        CollectibleManager.GetInstance().AddCollectible(itemID);
    }

    void NotStartDay()
    {
        bool active = CollectibleManager.GetInstance().GetID(itemID);
        Debug.Log(active);
        if (!active) Destroy(gameObject);
    }
}

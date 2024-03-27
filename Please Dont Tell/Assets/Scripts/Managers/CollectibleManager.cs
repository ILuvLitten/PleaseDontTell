using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{

    static CollectibleManager instance;

    static List<int> itemIDs = new List<int>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static CollectibleManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCollectible(int itemID)
    {
        itemIDs.Add(itemID);
        //Debug.Log(itemIDs);
    }

    public void DestroyID(int id)
    {
        itemIDs.Remove(id);
        //Debug.Log(itemIDs);
    }

    public bool GetID(int id)
    {
        return itemIDs.IndexOf(id) >= 0;
    }

}

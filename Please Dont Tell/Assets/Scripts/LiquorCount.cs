using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiquorCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] liquorCounts;

    static LiquorCount instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public static LiquorCount GetInstance()
    {
        return instance;
    }

    void Start()
    {
        
    }

    public void UpdateCount(int[] inventory)
    {
        if (inventory == null) return;
        liquorCounts[0].text = inventory[0].ToString();
        liquorCounts[1].text = inventory[1].ToString();
        liquorCounts[2].text = inventory[2].ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiquorCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] liquorCounts;

    static LiquorCount instance;

    static int[] staticLiquorCounts = new int[3];

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static LiquorCount GetInstance()
    {
        return instance;
    }

    void Start()
    {

        UpdateUI();
        
    }

    public void UpdateCount(int[] inventory)
    {
        if (inventory == null) return;
        staticLiquorCounts[0] = inventory[0];
        staticLiquorCounts[1] = inventory[1];
        staticLiquorCounts[2] = inventory[2];
        UpdateUI();

    }

    void UpdateUI()
    {

        liquorCounts[0].text = staticLiquorCounts[0].ToString();
        liquorCounts[1].text = staticLiquorCounts[1].ToString();
        liquorCounts[2].text = staticLiquorCounts[2].ToString();

    }

    public int[] GetInventory()
    {
        return staticLiquorCounts;
    }
}

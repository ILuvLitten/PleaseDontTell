using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    static NPCManager instance;

    static bool[] staticHasOrdered = new bool[4];
    static bool[] staticIsServed = new bool[4];
    static bool[] staticHasLeft = new bool[4];

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

    public static NPCManager GetInstance()
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

    public IEnumerator StartTimer(NPCController npc)
    {
        yield return new WaitForSeconds(30);
        
        yield return new WaitForSeconds(30);
        
        yield return new WaitForSeconds(30);

        yield return new WaitForSeconds(30);
        npc.Leave();
    }

    public bool GetHasOrdered(int ID)
    {
        return staticHasOrdered[ID];
    }

    public bool GetIsServed(int ID)
    {
        return staticIsServed[ID];
    }

    public bool GetHasLeft(int ID)
    {
        return staticHasLeft[ID];
    }
}

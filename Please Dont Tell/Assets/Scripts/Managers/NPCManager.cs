using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    static NPCManager instance;

    static bool[] staticHasOrdered = new bool[4];
    static bool[] staticIsServed = new  bool[4];
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
        //Debug.Log(staticHasOrdered[0] + " " + staticHasOrdered[1] + " " + staticHasOrdered[2] + " " + staticHasOrdered[3]);
    }

    /*public IEnumerator StartTimer(NPCController npc)
    {
        yield return new WaitForSeconds(30);
        
        yield return new WaitForSeconds(30);
        
        yield return new WaitForSeconds(30);

        yield return new WaitForSeconds(30);
        npc.Leave();
    }*/

    public void SetHasOrdered(int ID, bool value)
    {
        staticHasOrdered[ID] = value;
    }

    public void SetIsServed(int ID, bool value)
    {
        staticIsServed[ID] = value;
    }

    public void SetHasLeft(int ID, bool value)
    {
        staticHasLeft[ID] = value;
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

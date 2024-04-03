using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    static TimerManager instance;
    static bool timersActive = true;

    static List<float> timers = new List<float>();
    static List<string> timedNPCs = new List<string>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            StartCoroutine(UpdateTimers());
            DontDestroyOnLoad(instance);
        }
    }

    public static TimerManager GetInstance()
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

    public static void AddTimer(GameObject npc)
    {
        timers.Add(0f);
        timedNPCs.Add(npc.gameObject.name);
    }

    IEnumerator UpdateTimers()
    {

        while(timersActive)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i] > 40)
                {
                    //Debug.Log(GameObject.Find(timedNPCs[i]) + " lost all patience (4/4)");
                    if (GameObject.Find(timedNPCs[i]) != null) GameObject.Find(timedNPCs[i]).GetComponent<NPCController>().SetPatienceSprite(4);
                    yield break;
                }
                else if (timers[i] > 30)
                {
                    //Debug.Log(GameObject.Find(timedNPCs[i]) + " lost some patience (3/4)");
                    if (GameObject.Find(timedNPCs[i]) != null) GameObject.Find(timedNPCs[i]).GetComponent<NPCController>().SetPatienceSprite(3);
                }
                else if (timers[i] > 20)
                {
                    //Debug.Log(GameObject.Find(timedNPCs[i]) + " lost some patience (2/4)");
                    if (GameObject.Find(timedNPCs[i]) != null) GameObject.Find(timedNPCs[i]).GetComponent<NPCController>().SetPatienceSprite(2);
                }
                else if (timers[i] > 10)
                {
                    //Debug.Log(GameObject.Find(timedNPCs[i]) + " lost some patience (1/4)");
                    if (GameObject.Find(timedNPCs[i]) != null) GameObject.Find(timedNPCs[i]).GetComponent<NPCController>().SetPatienceSprite(1);
                }

                timers[i] += Time.deltaTime;
                //Debug.Log(timers[i]);

            }

            yield return new WaitForSeconds(0f);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquorCollectible : MonoBehaviour
{

    [SerializeField] int ID;
    public int itemID {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        itemID = ID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }*/
}

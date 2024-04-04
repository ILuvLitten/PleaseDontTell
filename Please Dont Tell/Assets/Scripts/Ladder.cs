using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    bool playerEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()!= null)
        {
            playerEnter = true;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            while(playerEnter)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()!= null)
        {
            playerEnter = false;
        }
    }

}

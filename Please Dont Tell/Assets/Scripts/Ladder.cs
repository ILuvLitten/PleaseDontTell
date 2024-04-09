using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    bool isTouching = true;
    Rigidbody2D rb;

    GameObject platform;
    [SerializeField] bool hasPlatform;

    // Start is called before the first frame update
    void Start()
    {

        platform = transform.GetChild(3).gameObject;
        platform.SetActive(hasPlatform);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (rb != null && isTouching && Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
        if(hasPlatform) platform.SetActive(!Input.GetKey(KeyCode.DownArrow));
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()!= null)
        {
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            isTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()!= null)
        {
            isTouching = false;
        }
    }

}

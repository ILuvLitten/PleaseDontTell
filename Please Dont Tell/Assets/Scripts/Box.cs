using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnColliderEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BottleThrow>() != null)
        {
            Destroy(gameObject);
        }
    }

}

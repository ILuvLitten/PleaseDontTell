using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;

    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {

        float z = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {
            x = target.transform.position.x;

            y = target.transform.position.y + 1;

            transform.position = new Vector3(x, y, -10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] Vector3 position1;
    [SerializeField] Vector3 position2;
    [SerializeField] float seconds;

    float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(position1, position2, t);
        }
        if (t > 1f)
        {
            Vector3 x;
            x = position1;
            position1 = position2;
            position2 = x;
            t = 0;
        }

    }
}

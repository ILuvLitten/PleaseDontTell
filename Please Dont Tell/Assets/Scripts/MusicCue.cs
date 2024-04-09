using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCue : MonoBehaviour
{

    [SerializeField] string title;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.GetInstance().Play(title);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleThrow : MonoBehaviour
{

    PlayerController player;

    [SerializeField] float rotationSpeed;
    [SerializeField] float speedX;
    [SerializeField] float speedY;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        rb.velocity = new Vector2(speedX * player.direction, speedY);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(rotationSpeed * -player.direction);
    }
}

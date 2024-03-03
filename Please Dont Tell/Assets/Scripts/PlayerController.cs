using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float attack;

    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.position = new Vector2(rb.position.x + horizontal * speed * Time.deltaTime, rb.position.y);
    }

    void Update()
    {
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

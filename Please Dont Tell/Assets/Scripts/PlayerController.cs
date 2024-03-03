using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float attack;

    [SerializeField] GameObject bottlePrefab;

    private float horizontal;
    private float vertical;
    public float direction { get; private set; }
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.position = new Vector2(rb.position.x + horizontal * speed * Time.deltaTime, rb.position.y);
        if (horizontal > 0) direction = 1;
        if (horizontal < 0) direction = -1;
    }

    void Update()
    {
        HandleJump();
        HandleAttack();
    }

    void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Instantiate(bottlePrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    }
}

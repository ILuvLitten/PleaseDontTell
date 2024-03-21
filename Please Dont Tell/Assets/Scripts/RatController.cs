using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{

    [SerializeField] float knockbackForce;
    [SerializeField] float health;
    [SerializeField] float speed;
    public bool canMove;
    public bool hostile = false;

    float switchTimer;
    public float switchNum = 1;
    [SerializeField] float switchTime;

    Rigidbody2D rb;
    Vector3 initialScale;
    Vector3 flippedScale;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        initialScale = transform.localScale;
        flippedScale = new Vector3(initialScale.x * -1, initialScale.y, initialScale.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hostile) 
        {
            Hostile();
        }
        else 
        {
            Passive();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (rb.velocity.x > 0)
        {
            transform.localScale = initialScale;
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = flippedScale;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hostile && other.gameObject.GetComponent<PlayerController>() != null)
        {
            InititateLaunchback(other.gameObject.GetComponent<PlayerController>().direction, 0);
        }
        if (hostile && other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.GetComponent<PlayerController>().Launchback(Mathf.Clamp(rb.velocity.x, -1, 1));
        }
    }

    public void InititateLaunchback(float direction, float damage)
    {
        // Coroutines run on the object they are called on no matter the script
        // Must be run on RatController even if StartCoroutine() via bottle is more efficient
        // Due to bottle immediately being destroyed after starting coroutine
        StopAllCoroutines();
        StartCoroutine(Launchback(direction));
        Damaged(damage);
    }

    public IEnumerator Launchback(float direction)
    {
        Debug.Log("launchback");
        rb.velocity = new Vector2(knockbackForce * direction, knockbackForce);
        yield return new WaitForSecondsRealtime(0.5f);
        hostile = true;
    }

    private void Damaged(float damage)
    {
        health -= damage;
    }

    public void Passive()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(speed/2 * switchNum, rb.velocity.y);
            switchTimer += 0.05f;
            if (switchTimer >= switchTime) 
            {
                switchNum = -switchNum;
                switchTimer = 0;
            }
        }
    }

    public void Hostile()
    {
        if (GameObject.Find("Player") == null) return;
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        if (playerPosition.x > transform.position.x) rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + 0.5f, 0, speed), rb.velocity.y);
        if (playerPosition.x < transform.position.x) rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x - 0.5f, -speed, 0), rb.velocity.y);
    }
}

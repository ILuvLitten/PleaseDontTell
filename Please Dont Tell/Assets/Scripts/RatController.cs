using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{

    [SerializeField] float knockbackForce;

    [SerializeField] float speed;
    bool hostile = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hostile) Hostile();
        else Passive();
    }

    public void InititateLaunchback(float direction)
    {
        // Coroutines run on the object they are called on no matter the script
        // Must be run on RatController even if StartCoroutine() via bottle is more efficient
        // Due to bottle immediately being destroyed after starting coroutine
        StartCoroutine(Launchback(direction));
    }

    public IEnumerator Launchback(float direction)
    {
        Debug.Log("launchback");
        rb.velocity = new Vector2(knockbackForce * direction, knockbackForce);
        yield return new WaitForSecondsRealtime(0.5f);
        hostile = true;
    }

    public void Passive()
    {

    }

    public void Hostile()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        if (playerPosition.x > transform.position.x) rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + 0.05f, 0, speed), rb.velocity.y);
        if (playerPosition.x < transform.position.x) rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x - 0.05f, -speed, 0), rb.velocity.y);
    }
}

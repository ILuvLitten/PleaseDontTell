using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public bool canMove = true;
    public bool canAttack = true;

    [SerializeField] float sceneNum;

    [SerializeField] Vector3 initialPosition;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    public float attack;
    [SerializeField] float health;
    [SerializeField] float knockbackForce;

    [SerializeField] GameObject bottlePrefab;

    private float horizontal;
    private float vertical;
    public float direction;
    private Vector3 startScale;

    private Rigidbody2D rb;
    [SerializeField] Animator anim;

    private DialogueManager dialogueManager;

    public int[] inventory;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        if (GameStateManager.GetInstance().GetDayBool(sceneNum))
        {
            StartDay();
        }
        else
        {
            NotStartDay();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (dialogueManager.dialogueIsPlaying) return;

        if (canMove)
        {
            horizontal = Input.GetAxis("Horizontal");

            rb.position = new Vector2(rb.position.x + horizontal * speed * Time.deltaTime, rb.position.y);
            if (horizontal > 0) direction = 1;
            if (horizontal < 0) direction = -1;
            transform.localScale = new Vector3(startScale.x * direction, startScale.y, startScale.z);

            anim.SetBool("isMoving", (horizontal == 0 ? false : true));
        }

    }

    void Update()
    {
        
        if (dialogueManager.dialogueIsPlaying) return;
        HandleTalk();

        if (canMove) HandleJump();
        if (canAttack) HandleAttack();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isJumping", true);
        }
        if (rb.velocity.y == 0) anim.SetBool("isJumping", false);
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            StopAllCoroutines();
            StartCoroutine("Throw");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(direction,-1,0), new Vector2(direction, 0), 1, LayerMask.GetMask("Rats"));
            if (hit.collider != null && hit.collider.gameObject.GetComponent<RatController>() != null)
            {
                hit.collider.gameObject.GetComponent<RatController>().InititateLaunchback(direction, attack);
            }
        }
    }

    void HandleTalk()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(direction,0,0), new Vector2(direction, 0), 0.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null && hit.collider.gameObject.GetComponent<NPCController>() != null && rb.velocity.y == 0)
            {
                hit.collider.gameObject.GetComponent<NPCController>().InitiateDialogue(inventory);
                anim.SetBool("isMoving", false);
            }
        }
    }

    IEnumerator Throw()
    {
        Instantiate(bottlePrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        anim.SetBool("isThrowing", true);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isThrowing", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<RatController>() != null && other.gameObject.GetComponent<RatController>().hostile)
        {
            Damaged(1);
        }
        if (other.gameObject.GetComponent<LiquorCollectible>() != null)
        {
            inventory[other.gameObject.GetComponent<LiquorCollectible>().drinkID] += 1;
            CollectibleManager.GetInstance().DestroyID(other.gameObject.GetComponent<LiquorCollectible>().itemID);
            LiquorCount.GetInstance().UpdateCount(inventory);
            PointsManager.GetInstance().AddPoints(50f);
            Destroy(other.gameObject);
        }
    }

    public void Launchback(float direction)
    {
        rb.velocity = new Vector2(knockbackForce * direction, knockbackForce);
    }

    public void Damaged(float damage)
    {
        health -= damage;
        HealthManager.GetInstance().UpdateHealth(health);
        Launchback(-direction);
    }

    void StartDay()
    {
        transform.position = initialPosition;
        health = 6;
        inventory = new int[3];
        direction = 1;
    }

    void NotStartDay()
    {

        health = HealthManager.GetInstance().GetHealth();
        inventory = LiquorCount.GetInstance().GetInventory();
        
    }

}

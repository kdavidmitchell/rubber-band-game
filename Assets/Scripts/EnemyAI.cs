using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameManager gm;
    private Animator animator;
    private Vector2 movement;
    private new Rigidbody2D rigidbody;
    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;

    private int health;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the enemy's animator, renderer, rigidbody, and player's rigidbody.
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Knight").GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = gm.EnemyParams.Health;
        speed = gm.EnemyParams.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("running", rigidbody.velocity.magnitude > float.Epsilon);

        // Flip sprite if needed
        // var flipSprite = spriteRenderer.flipX ? movement.x > 0.01f : movement.x < -0.01f;
        // if (flipSprite)
        // {
        //     spriteRenderer.flipX = !spriteRenderer.flipX;
        // }

        if (health <= 0)
        {
            gm.Evaluate(gameObject, 0, speed);
            Destroy(gameObject);
            gm.PlayerKill();
        }
    }

    public void FixedUpdate()
    {
        // rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.fixedDeltaTime);
        rigidbody.position = Vector2.MoveTowards(rigidbody.position, player.position, speed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Missile")) 
        {
            health -= 1;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            gm.Evaluate(gameObject, 1, speed);
            Destroy(gameObject);
            // Evaluate enemy
        }
    }
}

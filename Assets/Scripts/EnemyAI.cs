using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5;

    private Animator animator;
    private Vector2 movement;
    private new Rigidbody2D rigidbody;
    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the enemy's animator, renderer, rigidbody, and player's rigidbody.
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Knight").GetComponent<Rigidbody2D>();
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
    }

    public void FixedUpdate()
    {
        // rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.fixedDeltaTime);
        rigidbody.position = Vector2.MoveTowards(rigidbody.position, player.position, speed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileBehavior : MonoBehaviour
{
    private float _speed = 10f;
    private float _despawnTimer = 1f;
    private new Rigidbody2D rigidbody;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        targetPosition = GameObject.Find("Knight").GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {
        _despawnTimer -= Time.deltaTime;
        if (_despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        rigidbody.position = Vector2.MoveTowards(rigidbody.position, targetPosition, _speed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

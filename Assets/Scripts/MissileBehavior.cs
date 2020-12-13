using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    private float _speed = 10f;
    private float _despawnTimer = 1f;
    private new Rigidbody2D rigidbody;
    private Vector3 targetPosition;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        targetPosition = GameObject.Find("Knight").GetComponent<PlayerAttack>().TargetPosition;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _speed = gm.MissleSpeed;
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
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

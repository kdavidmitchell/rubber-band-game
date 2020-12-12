using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{

    public GameObject missilePrefab;
    private Vector3 _targetPosition;
    private float _attackDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Always going to be the player position.
        this.TargetPosition = GameObject.Find("Knight").GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {
        this.TargetPosition = GameObject.Find("Knight").GetComponent<Rigidbody2D>().position;
        
        _attackDelay -= Time.deltaTime;
        if (_attackDelay <= 0)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(missilePrefab, currentPos, Quaternion.identity);
    }

    public Vector3 TargetPosition 
    {
        get { return _targetPosition; }
        set { _targetPosition = value; }
    }
}

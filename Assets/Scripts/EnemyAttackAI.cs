using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{

    public GameObject missilePrefab;
    private Vector3 _targetPosition;
    private float _attackDelay = 1.0f;
    private float _timer; 

    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        // Always going to be the player position.
        this.TargetPosition = GameObject.Find("Knight").GetComponent<Rigidbody2D>().position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _timer = (gm.EnemyParams.Speed > 5) ? 0.5f : 1;
        _attackDelay = _timer;
    }

    // Update is called once per frame
    void Update()
    {   
        _attackDelay -= Time.deltaTime;
        if (_attackDelay <= 0)
        {
            ShootProjectile();
            _attackDelay = _timer;
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

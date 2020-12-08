using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordPrefab;
    private Vector3 _targetPosition;
    private float _timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.TargetPosition = gameObject.GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _timer <= 0)
        {
            this.TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ShootProjectile();
            _timer = 0.5f;
        }
    }

    void ShootProjectile()
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(swordPrefab, currentPos, Quaternion.identity);
    }

    public Vector3 TargetPosition 
    {
        get { return _targetPosition; }
        set { _targetPosition = value; }
    }
}

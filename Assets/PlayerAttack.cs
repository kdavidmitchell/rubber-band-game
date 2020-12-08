using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordPrefab;
    private Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.TargetPosition = gameObject.GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ShootProjectile();
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

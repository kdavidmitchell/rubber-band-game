using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(swordPrefab, currentPos, Quaternion.identity);
    }
}

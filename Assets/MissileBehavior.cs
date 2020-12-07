using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    private float _speed = 5f;
    private float _despawnTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
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
}

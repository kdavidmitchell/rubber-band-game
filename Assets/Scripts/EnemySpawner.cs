using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn first enemy before first frame update.
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Timer that determines spawn rate.
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 5f;
            SpawnEnemy();
        }
    }

    // Spawns enemy prefab in current position with no rotation.
    void SpawnEnemy() {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(enemy, currentPos, Quaternion.identity);
    }
}

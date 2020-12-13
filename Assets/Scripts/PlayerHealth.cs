using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int _health;
    private GameObject healthUI;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        // Set player health to 3 on start.
        this.Health = 3;
        // Get reference to the health UI gameobject.
        healthUI = GameObject.Find("PlayerHealthUI");
        // Get reference to gamemanager.
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitHealthUI(this.Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Health <= 0)
        {
            gm.PlayerDeath();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("EnemyMissile"))
        {
            this.Health -= 1;
            UpdateHealthUI(this.Health);
            gm.PlayerHit = true;
        }
    }

    void UpdateHealthUI(int health)
    {
        for (int i = 3; i > health; i--)
        {
            Image currentHeart = healthUI.transform.Find("Heart" + i).GetComponent<Image>();
            currentHeart.enabled = false;
        }
    }

    void InitHealthUI(int health)
    {
        for (int i = 1; i <= health; i++)
        {
            Image currentHeart = healthUI.transform.Find("Heart" + i).GetComponent<Image>();
            currentHeart.enabled = true;
        }
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
}

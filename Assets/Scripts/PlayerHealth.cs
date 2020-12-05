using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private GameObject healthUI;

    // Start is called before the first frame update
    void Start()
    {
        // Set player health to 3 on start.
        health = 3;
        // Get reference to the health UI gameobject.
        healthUI = GameObject.Find("PlayerHealthUI");
        // Display initial health UI.
        DisplayHealthUI(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "MaskedOrc") {
            Debug.Log("hit enemy");
        }
    }

    void DisplayHealthUI(int health) 
    {
        for (int i = 0; i < health; i++) 
        {
            Image currentHeart = healthUI.transform.Find("Heart" + i).GetComponent<Image>();
            currentHeart.enabled = true;
        }
    }
}

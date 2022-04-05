/* author: Mikolaj Malich */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= 10)
        {
            //testowa dekrementacja healthbar'a przy wcisnieciu klawisza m
            if (Input.GetKeyDown(KeyCode.M))
            {
                currentHealth -= 10;
                healthBar.SetHealth(currentHealth);
            }
        }
    }
}

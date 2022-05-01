/* author: Mikolaj Malich */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int baseLevel;
    private char _damageLevel = 'A';
    private string _path = "F_lvl1_A";
    public HealthBar healthBar;
    private SpriteRenderer _spriteR;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        baseLevel = 1;
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        _spriteR.sprite = Resources.Load<Sprite>(_path);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexturePath();
        if (currentHealth >= 10)
        {
            //testowa dekrementacja healthbar'a przy wcisnieciu spacji
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentHealth -= 10;
                healthBar.SetHealth(currentHealth);
            }
        }
    }

    void UpdateTexturePath()
    {
        if (currentHealth > 70) _damageLevel = 'A';
        else if (currentHealth > 20) _damageLevel = 'B';
        else _damageLevel = 'C';
        _path = "F_lvl" + baseLevel.ToString() + "_" + _damageLevel;
        _spriteR.sprite = Resources.Load<Sprite>(_path);
    }
}
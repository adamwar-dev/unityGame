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
    private Vector3 friendlyPosition = new Vector3(-19.025f, -3.145f, 0f);
    private Vector3 scale = new Vector3(0.8f, 0.7f, 0f);
    private static Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        baseLevel = 1;
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        _spriteR.sprite = Resources.Load<Sprite>(_path);
    }

    void Update()
    {
        UpdateBaseTexture();
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

    void UpdateBaseTexture()
    {
        if (currentHealth >= 70) _damageLevel = 'A';
        else if (currentHealth >= 30) _damageLevel = 'B';
        else _damageLevel = 'C';
        _path = "F_lvl" + baseLevel.ToString() + "_" + _damageLevel;
        _spriteR.sprite = Resources.Load<Sprite>(_path);
        TransformPosition();
    }

    void TransformPosition()
    {
        switch (_path)
        {
            case "F_lvl1_C":
            {
                friendlyPosition.Set(-19.06f, -3.37f, 0f);
                break;
            }
            default:
            {
                friendlyPosition.Set(-19.025f, -3.145f, 0f);
                break;
            }
        }

        transform.SetPositionAndRotation(friendlyPosition, rotation);
    }
}
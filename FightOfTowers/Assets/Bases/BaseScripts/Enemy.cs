/* author: Mikolaj Malich */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int baseLevel = 1;
    private char _damageLevel = 'A';
    private string _path = "lvl1_A";
    public HealthBar healthBar;
    private SpriteRenderer _spriteR;
    private Vector3 _enemyPosition = new Vector3(18.451f, -3.011f, 0f);
    private Vector3 _scale = new Vector3(0.8f, 0.7f, 0f);
    private static readonly Quaternion Rotation = new Quaternion(0f, 0f, 0f, 0f);

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        _spriteR.sprite = Resources.Load<Sprite>(_path);
    }

    void Update()
    {
        UpdateBaseTexture();
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

    void UpdateBaseTexture()
    {
        if (currentHealth >= 70) _damageLevel = 'A';
        else if (currentHealth >= 30) _damageLevel = 'B';
        else _damageLevel = 'C';
        _path = "lvl" + baseLevel.ToString() + "_" + _damageLevel;
        _spriteR.sprite = Resources.Load<Sprite>(_path);
        TransformPosition();
    }

    void TransformPosition()
    {
        switch (_path)
        {
             case "lvl1_A":
            {
                _enemyPosition.Set(20.0f, -2.6f, 0f);
                break;
            }
            case "lvl1_B":
            {
                _enemyPosition.Set(20.0f, -2.6f, 0f);
                break;
            }
            case "lvl1_C":
            {
                _enemyPosition.Set(20.0f, -2.6f, 0f);
                break;
            }
            case "lvl2_A":
            {
                _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            case "lvl2_B":
            {
               _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            case "lvl2_C":
            {
               _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_A":
            {
               _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_B":
            {
               _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_C":
            {
               _enemyPosition.Set(20.1f, -2.0f, 0f);
                break;
            }
            default:
            {
               _enemyPosition.Set(20.0f, -2.5f, 0f);
                break;
            }
        }

        transform.localScale = _scale;
        transform.SetPositionAndRotation(_enemyPosition, Rotation);
    }
}
/* author: Mikolaj Malich */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int baseLevel = 1;
    private char _damageLevel = 'A';
    private string _path = "lvl1_A";
    public HealthBar healthBar;
    private SpriteRenderer _spriteR;
    private Vector3 _friendlyPosition = new Vector3(-19.025f, -3.145f, 0f);
    private Vector3 _scale = new Vector3(0.8f, 0.7f, 0f);
    private static readonly Quaternion Rotation = new Quaternion(0f, 0f, 0f, 0f);

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        UpdateBaseTexture();
        _spriteR.sprite = Resources.Load<Sprite>(_path);
    }

    void Update()
    {
        UpdateBaseTexture();
        if (healthBar.slider.value >= 10)
        {
            //testowa dekrementacja healthbar'a przy wcisnieciu spacji
            if (Input.GetKeyDown(KeyCode.Space))
            {
                healthBar.SetHealth(healthBar.slider.value - 10);
            }
        }
    }

    void UpdateBaseTexture()
    {
        if (healthBar.slider.value >= (healthBar.slider.maxValue * (0.7))) _damageLevel = 'A';
        else if (healthBar.slider.value >= (healthBar.slider.maxValue * (0.3))) _damageLevel = 'B';
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
                _friendlyPosition.Set(-20.0f, -2.6f, 0f);
                break;
            }
            case "lvl1_B":
            {
                _friendlyPosition.Set(-20.0f, -2.6f, 0f);
                break;
            }
            case "lvl1_C":
            {
                _friendlyPosition.Set(-20.0f, -2.6f, 0f);
                break;
            }
            case "lvl2_A":
            {
                _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            case "lvl2_B":
            {
               _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            case "lvl2_C":
            {
               _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_A":
            {
               _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_B":
            {
               _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            case "lvl3_C":
            {
               _friendlyPosition.Set(-20.1f, -2.0f, 0f);
                break;
            }
            default:
            {
               _friendlyPosition.Set(-20.0f, -2.5f, 0f);
                break;
            }
        }

        transform.localScale = _scale;
        transform.SetPositionAndRotation(_friendlyPosition, Rotation);
    }
}
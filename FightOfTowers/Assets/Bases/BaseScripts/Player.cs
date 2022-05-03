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
    private Vector3 _friendlyPosition = new Vector3(-19.025f, -3.145f, 0f);
    private Vector3 _scale = new Vector3(0.8f, 0.7f, 0f);
    private static readonly Quaternion Rotation = new Quaternion(0f, 0f, 0f, 0f);

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        baseLevel = 3;
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        UpdateBaseTexture();
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
                _friendlyPosition.Set(-19.06f, -3.37f, 0f);
                break;
            }
            case "F_lvl2_A":
            {
                _friendlyPosition.Set(-18.809f, -1.428f, 0f);
                break;
            }
            case "F_lvl2_B":
            {
                _friendlyPosition.Set(-18.818f, -1.526f, 0f);
                break;
            }
            case "F_lvl2_C":
            {
                _friendlyPosition.Set(-18.8f, -2.601f, 0f);
                break;
            }
            case "F_lvl3_A":
            {
                _friendlyPosition.Set(-22.34f, -2.01f, 0f);
                break;
            }
            case "F_lvl3_B":
            {
                _friendlyPosition.Set(-22.35f, -2.02f, 0f);
                break;
            }
            case "F_lvl3_C":
            {
                _friendlyPosition.Set(-22.32f, -2.95f, 0f);
                break;
            }
            default:
            {
                _friendlyPosition.Set(-19.025f, -3.145f, 0f);
                break;
            }
        }

        if (baseLevel == 2 || baseLevel == 3) _scale.Set(0.7f, 0.6f, 0f);
        transform.localScale = _scale;
        transform.SetPositionAndRotation(_friendlyPosition, Rotation);
    }
}
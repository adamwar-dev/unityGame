/* author: Mikolaj Malich */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int baseLevel;
    private char _damageLevel = 'A';
    private string _path = "E_lvl1_A";
    public HealthBar healthBar;
    private SpriteRenderer _spriteR;
    private Vector3 enemyPosition = new Vector3(18.451f, -3.011f, 0f);
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
        _path = "E_lvl" + baseLevel.ToString() + "_" + _damageLevel;
        _spriteR.sprite = Resources.Load<Sprite>(_path);
        TransformPosition();
    }

    void TransformPosition()
    {
        switch (_path)
        {
            case "E_lvl1_B":
            {
                enemyPosition.Set(18.518f, -2.996f, 0f);
                break;
            }
            case "E_lvl1_C":
            {
                enemyPosition.Set(18.524f, -3.345f, 0f);
                break;
            }
            default:
            {
                enemyPosition.Set(18.451f, -3.011f, 0f);
                break;
            }
        }

        transform.SetPositionAndRotation(enemyPosition, rotation);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Piotr Czuczeło
    Adam Warzecha
    Mikolaj Malich
    Units fighting script.
*/
public class BaseFighting : MonoBehaviour
{
    public BoxCollider2D box;
    public HealthBar healtbar;
    public EndMenuOverScreen endMenu;
    private bool colisionExit = false;
    private float damage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider == box)
        {
            colisionExit = false;
            if ((col.gameObject.tag == "Enemy" && col.otherCollider.gameObject.tag == "FriendlyBase") ||
                (col.gameObject.tag == "Friendly" && col.otherCollider.gameObject.tag == "EnemyBase"))
            {
                GetDamage(col.gameObject.name);
                var objToDestroy = col.otherCollider.gameObject;

                StartCoroutine("BaseFight", objToDestroy);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.otherCollider == box)
        {
            Debug.Log("exit!");
            colisionExit = true;
        }
    }

    void BaseDestroy(GameObject gameObject)
    {
        //yield return new WaitForFixedUpdate();
        if (gameObject.tag == "FriendlyBase")
        {
            endMenu.SetupEndMenu(false);
        }
        else
        {
            endMenu.SetupEndMenu(true);
        }

        Destroy(gameObject);
    }

    IEnumerator BaseFight(GameObject Tower)
    {
        while (healtbar.slider.value > 0)
        {
            if (colisionExit == false)
            {
                yield return new WaitForSeconds(1);
                healtbar.SetHealth(healtbar.slider.value - damage);
            }
            else
            {
                break;
            }
        }

        if (healtbar.slider.value <= 0)
        {
            BaseDestroy(Tower);
        }
    }

    void GetDamage(string name)
    {
        if (name.Contains("Lvl1"))
        {
            if (name.Contains("Fighter"))
            {
                damage = 4;
            }
            else if (name.Contains("Shooter"))
            {
                damage = 6;
            }
            else if (name.Contains("Strong"))
            {
                damage = 8;
            }
            else
            {
                damage = 4;
            }
        }
        else if (name.Contains("Lvl2"))
        {
            if (name.Contains("Fighter"))
            {
                damage = 10;
            }
            else if (name.Contains("Shooter"))
            {
                damage = 12;
            }
            else if (name.Contains("Strong"))
            {
                damage = 14;
            }
            else
            {
                damage = 10;
            }
        }
        else if (name.Contains("Lvl3"))
        {
            if (name.Contains("Fighter"))
            {
                damage = 16;
            }
            else if (name.Contains("Shooter"))
            {
                damage = 18;
            }
            else if (name.Contains("Strong"))
            {
                damage = 20;
            }
            else
            {
                damage = 16;
            }
        }
        else
        {
            damage = 0;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Piotr Czuczeło
    Adam Warzecha
    Units fighting script.
*/
public class Fighting : MonoBehaviour
{

    public BoxCollider2D box;
    public Animator animator;   
    public UnitHealtbar healtbar;
    private bool colisionExit = false;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {

        /*
         *   Meteors
         */

        if(col.gameObject.tag == "Meteor" && col.otherCollider.gameObject.tag == "Enemy") {
            // current health - meteor dmg
            healtbar.SetHealth(healtbar.health - 10);
            Destroy (col.gameObject);
            if(healtbar.health <= 0)
                Destroy(col.otherCollider.gameObject);
        } else if (col.gameObject.tag == "Meteor" && col.otherCollider.gameObject.tag == "Friendly") {
            Destroy (col.gameObject);
        }

        /*
         *   Units && Bases
         */

        if(col.otherCollider == box){
            colisionExit = false;
            if((col.gameObject.tag == "Enemy" && col.otherCollider.gameObject.tag == "Friendly") ||
               (col.gameObject.tag == "Friendly" && col.otherCollider.gameObject.tag == "Enemy") ||
               (col.gameObject.tag == "EnemyBase" && col.otherCollider.gameObject.tag == "Friendly") ||
               (col.gameObject.tag == "FriendlyBase" && col.otherCollider.gameObject.tag == "Enemy")) {
                GetDamage(col.gameObject.name);   
                Debug.Log(damage);
                Debug.Log("Collision!");
                Debug.Log(col.gameObject.name);
                
                var objToDestroy = col.otherCollider.gameObject;
                
                StartCoroutine("Fight",objToDestroy);              
            }
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if(col.otherCollider == box){
            Debug.Log("exit!");
            colisionExit = true;
        }
    }
    
    void EnemyDestroy(GameObject gameObject){
        //yield return new WaitForFixedUpdate();
        animator.SetBool("Fight", false);
        Destroy (gameObject);
        Debug.Log("killed!");
    }

    IEnumerator Fight(GameObject friendly){
        while(healtbar.health > 0 ){

            if(colisionExit == false){
                animator.SetBool("Fight", true);
                Debug.Log("attack!");  
                Debug.Log(healtbar.health);
                yield return new WaitForSeconds(1);
                healtbar.SetHealth(healtbar.health - damage);
                
            }else{
                animator.SetBool("Fight", false);
                Debug.Log("break");
                break;
            } 
        }
        if(healtbar.health <= 0){
            Debug.Log("<=0!");
            EnemyDestroy(friendly);
        } 
    }

    void GetDamage(string name){

        if(name.Contains("Lvl1")){
           if(name.Contains("Fighter")){
               damage = 4;
           }else if(name.Contains("Shooter")){
               damage = 6;
           }else if(name.Contains("Strong")){
               damage = 8;
           }else{
               damage = 4;
           }
        }
        else if(name.Contains("Lvl2")){
            if(name.Contains("Fighter")){
                damage = 10;
           }else if(name.Contains("Shooter")){
               damage = 12;
           }else if(name.Contains("Strong")){
               damage = 14;
           }else{
               damage = 10;
           }
        }else if(name.Contains("Lvl3")){
            if(name.Contains("Fighter")){
                damage = 16;
           }else if(name.Contains("Shooter")){
               damage = 18;
           }else if(name.Contains("Strong")){
               damage = 20;
           }else{
               damage = 16;
           }
        }else{
                damage = 0;
        }

    }
}

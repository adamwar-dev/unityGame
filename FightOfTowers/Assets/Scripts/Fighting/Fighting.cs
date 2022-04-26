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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnCollisionEnter2D(Collision2D col) {

        if(col.otherCollider == box){
            
            if((col.gameObject.tag == "Enemy" && col.otherCollider.gameObject.tag == "Friendly") ||
               (col.gameObject.tag == "Friendly" && col.otherCollider.gameObject.tag == "Enemy")) {

                Debug.Log("Collision!");
                animator.SetBool("Fight", true);
                var objToDestroy = col.gameObject;

                yield return new WaitForSeconds(5);
                StartCoroutine("EnemyDestroy",objToDestroy);
                
                Debug.Log("killed!");            
            }
        }     
    }

    
    IEnumerator EnemyDestroy(GameObject gameObject){
        yield return new WaitForFixedUpdate();
        animator.SetBool("Fight", false);
        Destroy (gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Piotr Czuczeło
    Units fighting script.
*/
public class Fighting : MonoBehaviour
{

    public BoxCollider2D box;

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
            
            if(col.gameObject.tag == "Enemy" && col.otherCollider.gameObject.tag == "Friendly"){

                Debug.Log("Collision!");
                var objToDestroy = col.gameObject;

                yield return new WaitForSeconds(5);
                StartCoroutine("EnemyDestroy",objToDestroy);
                
                Debug.Log("killed!");            
            }
        }     
    }

    
    IEnumerator EnemyDestroy(GameObject gameObject){
        yield return new WaitForFixedUpdate();
        Destroy (gameObject);
    }
}

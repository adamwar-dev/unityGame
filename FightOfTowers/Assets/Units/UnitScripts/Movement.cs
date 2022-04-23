/*
    Adam Warzecha
    Piotr Czuczeło
    Units Movement script
*/

using UnityEngine;

public class Movement : MonoBehaviour
{
    public BoxCollider2D box;
    [SerializeField] bool ally;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementSpeed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(ally ? movementSpeed : -movementSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.otherCollider == box){

            animator.SetBool("Run", false);
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }    
    }

    void OnCollisionExit2D(Collision2D col) {
        rb.velocity = new Vector2(ally ? movementSpeed : -movementSpeed, 0);
        rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        animator.SetBool("Run", true); 
    }
}

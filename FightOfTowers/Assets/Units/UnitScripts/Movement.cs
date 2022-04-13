/*
    Adam Warzecha
    Units Movement script
*/

using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] bool ally;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementSpeed;

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
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("Collision!");
    }

    void OnCollisionExit2D(Collision2D col) {
         rb.velocity = new Vector2(ally ? movementSpeed : -movementSpeed, 0);
         rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
    }
}

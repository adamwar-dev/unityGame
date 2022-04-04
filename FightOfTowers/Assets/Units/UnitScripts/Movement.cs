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
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(ally ? movementSpeed : -movementSpeed, 0);
    }
}

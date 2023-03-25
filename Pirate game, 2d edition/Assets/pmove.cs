using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmove : MonoBehaviour
{
    public float moveSpeed = 3;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        movement.y = Input.GetAxis("Vertical") * moveSpeed;
        rb.AddForce(movement, ForceMode2D.Impulse);
    }
}

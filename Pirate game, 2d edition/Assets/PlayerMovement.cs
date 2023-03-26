using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int moveSpeed = 3;
    Rigidbody2D rb2d;
    private float horizontalMove;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() //movement
    {
        if (Input.GetKey("d"))                  
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
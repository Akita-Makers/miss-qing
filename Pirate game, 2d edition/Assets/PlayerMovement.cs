using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int moveSpeed = 3;
    Rigidbody2D rb2d;
    private float horizontalMove;
    public float JumpSpeed;
    public float RayCastDistance;
    public LayerMask GroundLayer;

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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKeyDown("space"))
        {
            //rb2d.AddForce(new Vector2(0, JumpSpeed), ForceMode2D.Impulse);
            if (Physics2D.Raycast(transform.position, Vector2.down, RayCastDistance, GroundLayer).collider != null)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, RayCastDistance, GroundLayer);
                Color rayColor;
                if (raycastHit.collider != null)
                {
                    rayColor = Color.green;
                }
                else
                {
                    rayColor = Color.red;
                }
                Debug.DrawRay(transform.position, Vector2.down * RayCastDistance, rayColor);
            }
        }
    }
}
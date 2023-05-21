using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public static float moveSpeed = 0;
    
    public float offset = 0f;
    public  float maxSpeed = 5f;
    private Rigidbody2D rb;
    private bool turning;
    Vector2 direction = new Vector2(0f,0f);
    Vector2 int_Direction = new Vector2(0f,0f);
    public Transform freePoint ;
    public Transform pivot;
    public Transform anchor;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int_Direction = (anchor.position - pivot.position).normalized;
        direction = int_Direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.D))
            {
                offset += 0.007f;
                if( offset >= 0.05)
                {
                    offset = 0.10f;
                }
            }
            if(Input.GetKey(KeyCode.A))
            {
                offset -= 0.007f;
                if( offset <= 0.05)
                {
                    offset = -0.10f;
                }
            }
        }
        else{
            offset = 0.0f;
        }

        if(Input.GetKey(KeyCode.W))
        {
            moveSpeed += 0.9f;
            if( moveSpeed >= 100f)
                {
                    moveSpeed = 100f;
                }
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveSpeed += -0.5f;
            if( moveSpeed <= 0f)
                {
                    moveSpeed = 0f;
                }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = freePoint.position;
        }
    }

    private void  FixedUpdate()
    {
        direction = ((anchor.position + transform.right * offset) - pivot.position).normalized;
        rb.AddForceAtPosition(direction.normalized * (moveSpeed / 10 ), pivot.position);
        
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(anchor.position, anchor.position + transform.right *offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed = 10f;
    public float rotateForce = 0.1f;
    private Quaternion rotation;
    private Rigidbody2D rb;
    Vector3 MousePos;
    Vector2 direction = new Vector2(0f,0f);
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (MousePos - transform.position).normalized ;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis( angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    private void  FixedUpdate()
    {
        rb.AddForce(direction * moveSpeed);
        float anglediff = Vector3.Angle(transform.position, direction);
        Vector3 cross = Vector3.Cross(transform.up, direction);
        rb.AddTorque(anglediff * cross.z * rotateForce);
    }
}

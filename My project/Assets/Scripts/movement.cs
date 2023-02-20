using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]private float speed = 2;
    private float acc = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            speed += acc;
        }
        if (Input.GetKey("s"))
        {
            speed -= acc;
        }
        transform.position += new Vector3(0,0,speed * Time.deltaTime);
    }
}

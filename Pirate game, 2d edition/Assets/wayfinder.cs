using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayfinder : MonoBehaviour
{
    public GameObject player;
    private GameObject target;
    private Vector2 dir;
    public float distToShip = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = resLogic.closest;
        dir = (target.transform.position - player.transform.position).normalized;
        transform.position = (Vector2)player.transform.position + dir * distToShip;
    }
}

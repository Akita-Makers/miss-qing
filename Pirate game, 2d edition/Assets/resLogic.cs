using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resLogic : MonoBehaviour
{
    public static GameObject closest;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        closest = findResPoint();
        if(hp.player_hp == 0 || Vector2.Distance(player.transform.position, closest.transform.position) > 50f)
        {
            Respawn(closest);
        }
    }
    public GameObject findResPoint()
    {
        GameObject[] points_List;
        GameObject closest = null;
        GameObject player = null;
        float distance = Mathf.Infinity;
        float curDist;
        
        player = GameObject.FindGameObjectWithTag("Player");
        points_List = GameObject.FindGameObjectsWithTag("Respawn");
        foreach(GameObject point in points_List)
        {
            curDist = Vector2.Distance(point.transform.position, player.transform.position);
            if(curDist< distance)
            {
                closest = point;
                distance = curDist;
            }
        }
        return closest;
    }

    public void Respawn(GameObject respoint)
    {
        //insert game over screen here
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        BasicMovement.moveSpeed = 0;
        player.transform.position = respoint.transform.position;
        hp.player_hp = 100;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GameObject.FindGameObjectWithTag("Player").transform.position, closest.transform.position);
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatmaker : MonoBehaviour
{
    public GameObject current_island;
    public GameObject[] islands;
    public GameObject target=null;
    public GameObject prefab;
    private GameObject ship = null;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        islands = GameObject.FindGameObjectsWithTag("Island");

        for(int i= 0;i < islands.Length; i++)
        {
            if(islands[i] == this.gameObject)
            {
                islands[i] = null;
            }
            target = get_Target(islands);
        }
    }

    // Update is called once per frame
    void Update()
    { /*Vector2.Angle(transform.up, target.transform.position - transform.position))*/
        if(ship == null)
        {
            ship = (GameObject)Instantiate(prefab, transform.Find("Respawn").transform.position ,Quaternion.identity);
            dir = (target.transform.position - ship.transform.position).normalized;
            //ship.transform.Find("Sprite").transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, -dir.y, 0), Vector2.up);
            Debug.Log("wat");
        }
        Vector3 velocity = dir * 4f * Time.deltaTime;
        ship.transform.position += velocity;
        ship.transform.rotation = Quaternion.Euler(0f,0f, -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg);
        float afstand = Vector2.Distance(ship.transform.position, target.transform.position);
        if( afstand < 10f )
        {
            Destroy(ship);
            target = get_Target(islands);
            /*Insert fadeout*/
        }
    }

    private GameObject get_Target(GameObject[] list)
    {
        GameObject target = list[Random.Range(0, islands.Length)];
        if(target == null)
        {
            while(target == null)
            {
                target = list[Random.Range(0, islands.Length)];
            }
        }
        return target;
    }

    private void spawnBoat(GameObject target)
    {
        ship = (GameObject)Instantiate(prefab, gameObject.transform.GetChild(1).transform.position ,Quaternion.identity);
        dir = (target.transform.position - ship.transform.position).normalized;
        ship.transform.Translate(dir * 0.9f * Time.deltaTime);
        if(Vector2.Distance(ship.transform.position, target.transform.position) < 10f)
        {
            /*Insert fadeout*/
        }
    }
    
    private void fade_out (SpriteRenderer ship)
    {
        
        ship.color = new Color (ship.color.r,ship.color.g, ship.color.b, ship.color.a -0.01f);
        if (ship.color.a == 0f)
        {
            
        }
    }
}

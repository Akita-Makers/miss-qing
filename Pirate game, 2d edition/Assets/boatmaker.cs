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
    {
        if(!ship)
        {
            ship = (GameObject)Instantiate(prefab, gameObject.transform.GetChild(1).transform.position ,Quaternion.identity);
            dir = (target.transform.position - ship.transform.position).normalized;
            Debug.Log("wat");
        }
        while(ship){
            ship.transform.Translate(dir * 0.9f * Time.deltaTime);
            if(Vector2.Distance(ship.transform.position, target.transform.position) < 5f)
            {
                ship = null;
                target = get_Target(islands);
                /*Insert fadeout*/
            }
        }
    }

    private GameObject get_Target(GameObject[] list)
    {
        return (list[Random.Range(0, islands.Length)]);
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

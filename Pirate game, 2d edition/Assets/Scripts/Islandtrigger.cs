using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Islandtrigger : MonoBehaviour
{
    public bool closeToAnIsland = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(closeToAnIsland)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(transform.name);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("It works");
        closeToAnIsland = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        closeToAnIsland = false;
    }
}

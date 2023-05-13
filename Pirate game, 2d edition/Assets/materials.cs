using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ships 
{
    public string name;
    public int ship_Id;
    public float speed;
    public GameObject preFab;
    [Range(0.0f, 100.0f)]
    public float cannon_Acu;
    public int cannon_Amount;
    public Ships(string name, int ship_Id, float speed, float cannon_Acu, int cannon_Amount)
    {
        this.name =  name;
        this.ship_Id = ship_Id;
        this.speed = speed;
        this.cannon_Acu = cannon_Acu;
        this.cannon_Amount = cannon_Amount;
    }
}

public class materials : MonoBehaviour
{
    public Ships small;
    public Ships mid;
    public Ships big;
    public GameObject small_Pre;
    public GameObject mid_Pre;
    public GameObject big_Pre;
    
    void Start()
    {
        small = new Ships("small", 1, 10.0f, 50.0f, 2);
        small.preFab = small_Pre;
        mid = new Ships("mid", 2, 15.0f, 70.0f, 3);
        mid.preFab = mid_Pre;
        big = new Ships("big", 3, 20.0f, 90.0f, 4);
        big.preFab = big_Pre;
    }
    
}







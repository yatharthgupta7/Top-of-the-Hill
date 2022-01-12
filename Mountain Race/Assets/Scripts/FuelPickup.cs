using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    //public Car car;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            col.gameObject.GetComponent<Car>().fuel=1;
            //car.fuel=1;
            Destroy(gameObject); 
        }
    }
}

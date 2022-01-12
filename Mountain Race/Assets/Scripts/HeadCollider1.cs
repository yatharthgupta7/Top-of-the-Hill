using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Ground")
        {
            GetComponentInParent<Car1>().Death();
        }
    }
}

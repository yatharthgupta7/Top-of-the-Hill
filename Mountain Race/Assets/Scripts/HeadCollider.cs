using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Ground")
        {
            GetComponentInParent<Car>().isDead=true;
            GetComponentInParent<Car>().Wait();
        }
    }
}

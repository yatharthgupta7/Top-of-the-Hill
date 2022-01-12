using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Ground")
        {
            GetComponentInParent<Car>().isGrounded=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Ground")
        {
            GetComponentInParent<Car>().isGrounded=false;
        }
    }
}

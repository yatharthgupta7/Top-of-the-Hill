using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    
    public PolygonCollider2D[] m_Collider;
    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Ground")
        {
            Debug.Log("Ground");
            m_Collider[0].enabled = false;//!m_Collider.enabled;
            m_Collider[1].enabled = false;//!m_Collider.enabled;
            rb.gravityScale=0f;
        }
    }
}

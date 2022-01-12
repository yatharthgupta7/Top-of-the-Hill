using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{    
    public Transform[] target;
    public Vector3 offset;
    public float minY,maxY;

    public int selected=0;

    void Start()
    {
        offset=transform.position-target[selected].position;
    }
    void Update()
    {
        Vector3 pos=target[selected].position+offset;
        pos.y=Mathf.Clamp(pos.y,minY,maxY);
        transform.position=pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CoinSpawner : MonoBehaviour
{
    public SpriteShapeController[] shapeController;

    public GameObject coin;


    void Start()
    {
        foreach(SpriteShapeController s in shapeController)
        {
            int points=s.spline.GetPointCount();
        
            for(int x=10;x<=points;x+=10)
            {
                Vector3 po=s.spline.GetPosition(x);
                GameObject ob= Instantiate(coin,po,Quaternion.identity);
            }
        }
    }
}

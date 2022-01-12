using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlatformCreater : MonoBehaviour
{
    public GameObject fuel;
    public GameObject bgObject;
    public SpriteShapeController shapeController;
    public int scale=10000;
    public int numberOfPoint=6000;
    void Start()
    {
        shapeController =GetComponent<SpriteShapeController>();
        
        float distanceBtwPoints=(float)scale/ (float)numberOfPoint;
        shapeController.spline.SetPosition(2,shapeController.spline.GetPosition(2)+Vector3.right*scale);
        shapeController.spline.SetPosition(3,shapeController.spline.GetPosition(3)+Vector3.right*scale);

        for(int i=0;i<numberOfPoint;i++)
        {
            float xPos;
                xPos=shapeController.spline.GetPosition(i+1).x+distanceBtwPoints;

            if(i<10)
            {
            shapeController.spline.InsertPointAt(i+2,new Vector3(xPos,8* Mathf.PerlinNoise(i*Random.Range(1f,2.5f),0)));
            }
            else{
            shapeController.spline.InsertPointAt(i+2,new Vector3(xPos,8* Mathf.PerlinNoise(i*Random.Range(1f,8.5f),0)));
            }
        }

        for(int i=2;i<152;i++)
        {
            shapeController.spline.SetTangentMode(i,ShapeTangentMode.Continuous);
            shapeController.spline.SetLeftTangent(i,new Vector3(-1,0,0));
            shapeController.spline.SetRightTangent(i,new Vector3(1,0,0));
        }

        for(int i=10;i<=numberOfPoint;i+=40)
        {
            Vector3 po=shapeController.spline.GetPosition(i);
            Debug.Log(po.y);
            po.y-=2f;
            GameObject ob= Instantiate(fuel,po,Quaternion.identity);
            Vector3 p=ob.transform.position;
            p.y=p.y-1f;
            ob.transform.position=p;
            float distance=ob.transform.position.y-po.y;
            if(distance>1)
            {
                distance=distance-(distance-1);
                p.y=distance;
                ob.transform.position=p;
            }
        }
        int amount=Random.Range(1,2);
        


        
    }

    void Update()
    {
        
    }
}

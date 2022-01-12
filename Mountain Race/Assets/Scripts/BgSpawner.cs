using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{

    public GameObject backGround;
    public GameObject bgObject;
    public int  amount;
    void Start()
    {
        amount=Random.Range(2,5);
        for(int x=0;x<3020;x+=50)
        {
            for(int y=1;y<=amount;y++)
            {
                Instantiate(backGround,new Vector2(x+Random.Range(1f,3f),Random.Range(5f,10f)),Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLogic : MonoBehaviour
{
    public Image fuelImage;
    public Rigidbody2D frontWheel,backWheel;
    public Rigidbody2D car;
    public float carSpeed,carTorque;
    public float fuel=1f;
    public float fuelConsumption=0.1f;

     float input;

    void Update()
    {
        input=Input.GetAxis("Horizontal");
        fuelImage.fillAmount=fuel;
    }

    void FixedUpdate()
    {
        if(fuel>0)
        {
        frontWheel.AddTorque(-input*carSpeed*Time.fixedDeltaTime);
        backWheel.AddTorque(-input*carSpeed*Time.fixedDeltaTime);
        car.AddTorque(-input*carTorque *Time.fixedDeltaTime);
        }

        fuel-=fuelConsumption*Mathf.Abs(input)*Time.fixedDeltaTime;
    }    
    public void OnGas()
    {
        if(fuel>0)
        {
            SetTorque(-carSpeed);
        }
    }

    public void OnBrake()
    {
        if(fuel>0)
        {
            SetTorque(carSpeed);
        }
    }

    void SetTorque(float speed)
    {
        /*foreach(Axle axle in axles)
        {
            axle.wheel.AddTorque(speed * axle.speedMultiplier);
        }*/
        
        frontWheel.AddTorque(speed*Time.fixedDeltaTime);
        backWheel.AddTorque(speed*Time.fixedDeltaTime);
        car.AddTorque(speed* Time.fixedDeltaTime);
        
        fuel-=fuelConsumption*Time.fixedDeltaTime;

        //rb.AddTorque(rotation * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MyCarSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float minPitch = 0.05f;
    private float pitchFromCar;
    public Car car;
     
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
        car=GetComponentInParent<Car>();
    }
 
    // Update is called once per frame
    void Update()
    {
        pitchFromCar = car.axles[0].wheel.velocity.magnitude;
        if(pitchFromCar>10)
        {
            pitchFromCar=10f;
        }
        if(pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromCar;
    }
}
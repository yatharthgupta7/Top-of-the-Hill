using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Car1 : MonoBehaviour
{
    public float speed;
    public Axle1[] axles;
    
    public int distanceUnit=0;
    public Text distanceCoveredText;

    public float rotation;

    public Rigidbody2D rb;
    public float fuel=1f;
    public float fuelConsumption=0.1f;
    public Image fuelImage;

    public Transform startPos;
    public float distanceFromStartPos;

    public float brakeFactor=75f;

    public GameObject deathMenu;
    public Text deathMenuDistanceText;


    public void Death()
    {
        Respawn();
    }

    public void Respawn()
    {
        StartCoroutine(WaitTime());
    }

    void Start()
    {       
    }

    public void OnGas()
    {
        SetTorque(-speed);
    }

    public void OnBrake()
    {
        SetTorque(speed);
    }

    public void Brake()
    {
        foreach(Axle1 axle in axles)
        {
            Debug.Log(axle.wheel.velocity.magnitude);
            var localVel = transform.InverseTransformDirection(axle.wheel.velocity);
            if(axle.wheel.velocity.magnitude>1)
            {
                if(localVel.x<0)
                {
                    SetTorque(-25f);
                }
                else
                {
                    SetTorque(25f);
                }
            }
        }
    }


    void SetTorque(float speed)
    {
        fuel-=fuelConsumption*Time.fixedDeltaTime;
        if(fuel<0)
        {
            StartCoroutine(FuelFinished());
            return;
        }
        foreach(Axle1 axle in axles)
        {
            axle.wheel.AddTorque(speed * axle.speedMultiplier*Time.deltaTime);
        }
        if(speed>0)
        {
            rb.AddTorque(rotation * 10f*Time.deltaTime);
        }
        else
        {
            rb.AddTorque(rotation * -10f*Time.deltaTime);
        }
        
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale=1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Wait()
    {
        StartCoroutine(FuelFinished());
    }

     IEnumerator FuelFinished()
    {
        yield return new WaitForSeconds(3f);
        
            Death();
    }     
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        transform.position=startPos.position;
    }

    void distance()
    {
        distanceUnit=distanceUnit+1;
        distanceCoveredText.text=distanceUnit.ToString();
    }

    void Update()
    {
        fuelImage.fillAmount=fuel;
        distanceFromStartPos = ( transform.position.x -startPos.transform.position.x );
        distanceCoveredText.text=((int)distanceFromStartPos).ToString();
    }


}

[System.Serializable]
public class Axle1
{
    public Rigidbody2D wheel;
    public float speedMultiplier;

}
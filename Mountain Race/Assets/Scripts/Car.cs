using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed;

    public bool isMuted;
    public Axle[] axles;
    
    public int coin;
    public Text coinText;
    public CarPedal[] pedal;
    public float maxSpeed=-100;

    public GameObject carImage;
    
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
    public Text deathMenuCoinText;

    public bool isDead;
    public bool isGrounded;

    public Vector3 anglesToRotate;


    public GameObject pauseMenu;

    public void Death()
    {
        deathMenu.SetActive(true);
        Time.timeScale=0f;
        deathMenuDistanceText.text=((int)distanceFromStartPos).ToString();
        float highScore=PlayerPrefs.GetFloat("HighScore");
        if(distanceFromStartPos>highScore)
        {
            PlayerPrefs.SetFloat("HighScore",distanceFromStartPos);
        }
        deathMenuCoinText.text=coin.ToString();

        int revCoin=PlayerPrefs.GetInt("Coins");
        revCoin+=coin;
        PlayerPrefs.SetInt("Coins",revCoin);
    }

    public void Pause()
    {
        Time.timeScale=0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale=1f;
        pauseMenu.SetActive(false);
    }



    void Start()
    {       
        isDead=false;
        isMuted=false;
    }

    public void MutePressed()
    {
        isMuted=!isMuted;
        AudioListener.pause=isMuted;
    }

    public void OnGas()
    {
        if(!isDead)
        {
            SetTorque(-speed);
        }
    }

    public void OnBrake()
    {
        if(!isDead)
        {
            SetTorque(speed);
        }
    }

    public void Brake()
    {
        if(isDead)
        {
            return;
        }
        foreach(Axle axle in axles)
        {
            //Debug.Log(axle.wheel.velocity.magnitude);
            var localVel = transform.InverseTransformDirection(axle.wheel.velocity);
            if(axle.wheel.velocity.magnitude>1)
            {
                if(localVel.x<0)
                {
                    //SetTorque(-25f);
                }
                else
                {
                    //SetTorque(25f);
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
        foreach(Axle axle in axles)
        {
            axle.wheel.AddTorque(speed * axle.speedMultiplier*Time.deltaTime);
            
                if(axle.wheel.angularVelocity < maxSpeed*25 ) 
                {
                    axle.wheel.angularVelocity = speed;
                } else if(axle.wheel.angularVelocity > -maxSpeed*25 )
                {
                    axle.wheel.angularVelocity = speed;
                }
        }

        rb.AddTorque(rotation * Time.deltaTime);
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

        coinText.text=coin.ToString();
        
    }

    public void CoinCollide()
    {
        coin+=100;
    }
    void FixedUpdate()
    {
        if(!pedal[0].isMouseDown&&!pedal[1].isMouseDown)
        {
            Debug.Log("front tire -"+axles[0].wheel.angularVelocity );
            foreach(Axle axle in axles)
            {
                if(axle.wheel.angularVelocity < maxSpeed ) 
                {
                    axle.wheel.angularVelocity = 10f;
                } else if(axle.wheel.angularVelocity > -maxSpeed )
                {
                    axle.wheel.angularVelocity = -10f;
                }
            }
        }
    }   


}

[System.Serializable]
public class Axle
{
    public Rigidbody2D wheel;
    public float speedMultiplier;

}
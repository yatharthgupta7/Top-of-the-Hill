using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Car car;
    void Start()
    {
        
    }

    void Update()
    {
        car.OnGas();
    }

    public void Play()
    {
        SceneManager.LoadScene("Characters");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

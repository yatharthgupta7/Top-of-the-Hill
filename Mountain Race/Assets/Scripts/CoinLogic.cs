using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pickUp;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            col.GetComponent<Car>().CoinCollide();
            audioSource.PlayOneShot(pickUp);
            Destroy(gameObject,0.1f);
        }
    }
}

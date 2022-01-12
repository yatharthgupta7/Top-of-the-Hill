using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSelectedCharacter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bg;
    public GameObject[] characterList;
    public CameraLogic cameraLogic;
    int index;
    void Start()
    {
        index=PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];
        for (int x = 0; x < transform.childCount; x++)
        {
            characterList[x] = transform.GetChild(x).gameObject;
        }
        characterList[index].SetActive(true);
        cameraLogic.selected=index;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

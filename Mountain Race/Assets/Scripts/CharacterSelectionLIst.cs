using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionLIst : MonoBehaviour
{
    public GameObject[] characterList;
    public GameObject buy;
    public Button locked;
    
    public Text coinText;
    public Text buyText;
    int index;

    public int bikeAmt;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("CharacterSelected"));
        coinText.text = "- " + ((int)PlayerPrefs.GetInt("Coins")).ToString();
        index=PlayerPrefs.GetInt("CharacterSelected");
        PlayerPrefs.SetInt("YellowCar",1);
        if(PlayerPrefs.HasKey("Bike"))
        {
            PlayerPrefs.SetInt("Bike", 0);
            index = 0;
        }

        characterList = new GameObject[transform.childCount];
        for (int x = 0; x < transform.childCount; x++)
        {
            characterList[x] = transform.GetChild(x).gameObject;
        }
        foreach(GameObject g in characterList)
        {
            g.SetActive(false);
        }

        if(characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }
    
    public void ToggleLeft()
    {
        
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);

        if(index==1&&(PlayerPrefs.GetInt("Bike")==0))
        {
            locked.interactable = true;
            buy.SetActive(true);
        }
        else if(index!=1)
        {
            //Disable Button
            locked.interactable = false;
            buy.SetActive(false);
        }
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
        if(index==1 && (PlayerPrefs.GetInt("Bike")==0))
        {
            //Enale Button
            locked.interactable = true;
            buy.SetActive(true);
        }
        else if(index!=1)
        {
            //Disable Button
            locked.interactable = false;
            buy.SetActive(false);
        }
    }

    

    public void Buy()
    {
        float coin = PlayerPrefs.GetInt("Coins");
        if(coin>=bikeAmt)
        {
            PlayerPrefs.SetInt("Bike", 1);
            PlayerPrefs.SetInt("Coins", (int)(coin - bikeAmt));

            coinText.text = "- " + ((int)PlayerPrefs.GetInt("Coins")).ToString();
            //Disable buy button
            locked.interactable = false;
            buy.SetActive(false);
        }
    }

    

    public void ConfirmButton()
    {
        if(index==1 && PlayerPrefs.GetInt("Bike")==1)
        {
            PlayerPrefs.SetInt("CharacterSelected", index);
            SceneManager.LoadScene("LevelLoader");
        }
        else if(index==0)
        {
            PlayerPrefs.SetInt("CharacterSelected", index);
            SceneManager.LoadScene("LevelLoader");
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        
    }
}

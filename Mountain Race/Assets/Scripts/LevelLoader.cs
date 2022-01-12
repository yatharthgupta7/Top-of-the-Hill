using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Sprite[] levelImages;

    public string[] levelNames;
    public Image levels;
    public Text showText;
    public int index=0;

    void Start()
    {
        levels.sprite=levelImages[index];
        showText.text=levelNames[index];
    }
    
    
    public void ToggleLeft()
    {
        

        index--;
        if (index < 0)
        {
            index = levelImages.Length - 1;
        }
        showText.text=levelNames[index];

        levels.sprite=levelImages[index];
    }

    

    public void ToggleRight()
    {

        index++;
        if (index == levelImages.Length)
        {
            index = 0;
        }
        
        showText.text=levelNames[index];
        levels.sprite= levelImages[index];
    }
    void Update()
    {
        
    }

    public void ConfirmButton()
    {
        SceneManager.LoadScene("Level "+(index+1));
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    #region Singletom

    public static GameManeger instance;
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    #endregion
    
    public Text coinText;
    public int coin;
    
    void Start()
    {
        coin=PlayerPrefs.GetInt("Coins");
    }

    void Update()
    {
        
    }
}

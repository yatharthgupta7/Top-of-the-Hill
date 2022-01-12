using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CarPedal : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Sprite defaultSprite,pressedSprite;
    public Image  graphicComponent;
    public bool isMouseDown;
    public Car[] player;
    int index;

    public UnityEvent onMouse;
    void Start()
    {
        graphicComponent.sprite=defaultSprite;
        index=PlayerPrefs.GetInt("CharacterSelected");
    }

    void Update()
    {
        if(isMouseDown)
        {
            onMouse.Invoke();
        }
        else
        {
            foreach(Car p in player)
            {
                //p.Brake();
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseDown=true;
        graphicComponent.sprite=pressedSprite;

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown=false;
        graphicComponent.sprite=defaultSprite;
    }

    
}

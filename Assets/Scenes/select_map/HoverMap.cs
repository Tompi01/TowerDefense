using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image img;
    void Start()
    {
        img = GetComponent<Image>(); 

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = Color.white;
        Debug.Log("Enter");
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        img.color = Color.gray;
        //img.color = Color.red;
    }
}

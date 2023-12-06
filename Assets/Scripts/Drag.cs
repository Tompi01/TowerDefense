using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    static public GameObject itemBeignDragged;
    static public itemInfo tmpInfo;


    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject duplicate = Instantiate(gameObject);
        itemBeignDragged = duplicate;
        RectTransform tmpRT = gameObject.GetComponent<RectTransform>();

        RectTransform rt = itemBeignDragged.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(tmpRT.sizeDelta.x, tmpRT.sizeDelta.y);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        tmpInfo = GetComponent<itemInfo>();
        Transform canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        itemBeignDragged.transform.SetParent(canvas);
        itemBeignDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeignDragged.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //x@GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    
}

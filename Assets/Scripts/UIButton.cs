using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Fabric.EventManager.Instance.PostEvent("UI/UISelect", Camera.main.gameObject);
    }

}

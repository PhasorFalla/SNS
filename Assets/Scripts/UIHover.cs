using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Panel;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Panel.SetActive(false);
    }

	
}

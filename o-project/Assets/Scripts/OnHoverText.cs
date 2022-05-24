using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.black; //Or however you do your color
    }
    public void OnDeselect(PointerEventData eventData)
    {
        theText.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; //Or however you do your color
    }
}

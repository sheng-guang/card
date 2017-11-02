using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class mini_3d_Get : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData D)
    {
        if (D.button == PointerEventData.InputButton.Middle)
        {
            print("point_this");
        }
    }
}

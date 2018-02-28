using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class map_usecard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public clientPlayer center;
    public float L;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 local = new Vector3(eventData.position.x, eventData.position.y, 0) - transform.position;
        Vector3 local_l = local / L;
        center.clickMap(local_l);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

}

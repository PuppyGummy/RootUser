using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 MouseDragStartPos;
    public PointerEventData.InputButton dragMouseButton;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == dragMouseButton){
            transform.localPosition = Input.mousePosition - MouseDragStartPos;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDragStartPos = Input.mousePosition - transform.localPosition;
        transform.SetAsLastSibling();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

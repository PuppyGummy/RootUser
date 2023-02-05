using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class WindowUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 MouseDragStartPos;
    RectTransform rectTransform;
    public PointerEventData.InputButton dragMouseButton;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == dragMouseButton)
        {
            transform.localPosition = Input.mousePosition - MouseDragStartPos;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDragStartPos = Input.mousePosition - transform.localPosition;
        transform.SetAsLastSibling();
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(1, 0.5f).From(0);
    }

    public void OnActive(){
        gameObject.SetActive(true);
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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

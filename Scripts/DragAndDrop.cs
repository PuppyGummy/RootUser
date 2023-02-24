using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public GameObject tranformLayer;
    public Image icon;
    private Transform upLayer;
    private Camera cam;
    [SerializeField] GameObject decoderWindow;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        upLayer = tranformLayer.GetComponent<Transform>();
        if (decoderWindow.activeSelf)
        {
            transform.SetParent(upLayer);
        }
        transform.SetAsLastSibling();
        icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        icon.raycastTarget = true;
    }

    void Start()
    {
        cam = Camera.main;
    }
}

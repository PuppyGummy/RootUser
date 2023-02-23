using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class WindowUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    Vector3 MouseDragStartPos;
    RectTransform rectTransform;
    public PointerEventData.InputButton dragMouseButton;
    Camera mainCamera;
    public Canvas canvas;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == dragMouseButton)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDragStartPos = Input.mousePosition - transform.localPosition;
        transform.SetAsLastSibling();
    }

    public void OnOpen()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            transform.SetAsLastSibling();
            rectTransform.localScale = Vector3.zero;
            rectTransform.DOScale(1, 0.5f).From(0);
        }
    }

    public void OnActive()
    {
        gameObject.SetActive(true);
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }
}

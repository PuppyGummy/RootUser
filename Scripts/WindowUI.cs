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
    Camera mainCamera;
    public Canvas canvas;
    public GameObject miniObject;
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
        // if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            rectTransform.localScale = Vector3.zero;
            rectTransform.DOScale(1, 0.5f).From(0);
            transform.SetAsLastSibling();
        }
    }

    public void OnMinimize()
    {
        // 获取需要复制的Object
        GameObject original = this.gameObject;

        // 创建一个新的GameObject作为副本
        GameObject copy = Instantiate(original);

        // 设置新对象的父级对象为原始对象的父级对象
        copy.transform.SetParent(original.transform.parent);

        // 获取miniobject在屏幕上的绝对位置
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(miniObject.transform.position);

        // 将miniobject的屏幕坐标转换为当前Canvas上的局部坐标
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(miniObject.GetComponent<RectTransform>(), screenPosition, Camera.main, out localPosition);


        // 将副本放置在原始对象的位置
        copy.transform.position = original.transform.position;


        // 获取副本和原始对象的RectTransform组件
        RectTransform originalRect = original.GetComponent<RectTransform>();
        RectTransform copyRect = copy.GetComponent<RectTransform>();

        // 副本的缩放和pivot与源对象一致
        copyRect.localScale = originalRect.localScale;
        copyRect.pivot = originalRect.pivot;

        // 将副本的缩放属性缩小为0
        copyRect.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutQuad);
        //设置终点
        copyRect.DOPivot(localPosition, 0.5f).SetEase(Ease.OutQuad);
        Debug.Log(localPosition);
        Debug.Log(miniObject.transform.position);

        //gameObject.SetActive(false);
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

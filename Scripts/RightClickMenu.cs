using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RightClickMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public PointerEventData.InputButton clickMouseButton;
    public TMP_InputField inputField;
    public string password = "longlivenirvana";
    private bool selected = false;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            MenuPanel.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            MenuPanel.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            MenuPanel.SetActive(false);
        }
    }

    public void Paste()
    {
        if (inputField.gameObject.activeSelf)
        {
            inputField.text = password;
        }
    }
}

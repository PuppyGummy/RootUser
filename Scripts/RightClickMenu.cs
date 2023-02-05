using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public PointerEventData.InputButton clickMouseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(1)){
            MenuPanel.transform.position = Input.mousePosition;
            MenuPanel.SetActive(true);
        }
        if(Input.GetMouseButtonUp(0)){
            MenuPanel.SetActive(false);
        }
    }
}

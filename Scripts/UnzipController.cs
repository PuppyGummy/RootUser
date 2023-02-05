using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnzipController : MonoBehaviour
{
    private string inputPassword;
    [SerializeField] private GameObject unzipWindow;
    [SerializeField] private GameObject loadingWindow;
    [SerializeField] private GameObject desktopPic1;
    [SerializeField] private GameObject desktopPic2;
    [SerializeField] private GameObject desktopPic3;
    [SerializeField] private GameObject decoder;
    [SerializeField] private GameObject soundEffect;
    // Start is called before the first frame update

    public void readPasswordInput(string s){
        inputPassword = s;
        Debug.Log(inputPassword);
        if(inputPassword == "1987"){
            unzipWindow.SetActive(false);
            loadingWindow.SetActive(true);
            desktopPic1.SetActive(true);
            desktopPic2.SetActive(true);
            desktopPic3.SetActive(true);
            decoder.SetActive(true);
            soundEffect.SetActive(true);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnzipController : MonoBehaviour
{
    private string inputPassword;
    [SerializeField] private GameObject unzipWindow;
    [SerializeField] private GameObject loadingWindow;
    [SerializeField] private GameObject desktopPic1;
    [SerializeField] private GameObject decoder;
    [SerializeField] private GameObject soundEffect;
    // Start is called before the first frame update

    public void readPasswordInput(string s)
    {
        inputPassword = s;
        Debug.Log(inputPassword);
        if (inputPassword == "1987")
        {
            unzipWindow.SetActive(false);
            loadingWindow.SetActive(true);
            soundEffect.SetActive(true);
            Invoke("ShowFiles", 2.4f);
        }

    }
    void ShowFiles()
    {
        desktopPic1.SetActive(true);
        decoder.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentsPathController : MonoBehaviour
{
    private string inputPath;
    [SerializeField] private GameObject Resume;
    [SerializeField] private GameObject Summon;


    [SerializeField] private GameObject research;
    [SerializeField] private GameObject record;
    [SerializeField] private GameObject NewsA;
    [SerializeField] private GameObject NewsB;
    // Start is called before the first frame update
    public void readPathInput(string s){
        inputPath = s;
        Debug.Log(inputPath);
        if(inputPath == "C:/xxx/xxxx"){
            research.SetActive(false);
            record.SetActive(false);
            NewsA.SetActive(false);
            NewsB.SetActive(false);
            Resume.SetActive(true);
            Summon.SetActive(true);

        }
        else if(inputPath == "OS:/ROOT"){
            Resume.SetActive(false);
            Summon.SetActive(false);
            research.SetActive(true);
            record.SetActive(true);
            NewsA.SetActive(true);
            NewsB.SetActive(true);
        }
    }
}

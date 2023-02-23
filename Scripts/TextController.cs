using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TextController : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public InMemoryVariableStorage variableStorage;
    public bool isCode = false;
    void OnEnable()
    {
        bool visitedCode = false;
        bool visitedBinary = false;
        variableStorage.TryGetValue("$visitedCode", out visitedCode);
        variableStorage.TryGetValue("$visitedBinary", out visitedBinary);
        Debug.Log("visitedCode: " + visitedCode);
        Debug.Log("visitedBinary: " + visitedBinary);
        if (!isCode && !visitedBinary)
        {
            StartCoroutine(WaitToStartChat(5f, "BinaryNumbers"));
        }
        else if (isCode && !visitedCode)
        {
            StartCoroutine(WaitToStartChat(5f, "Code"));
        }
    }
    IEnumerator WaitToStartChat(float time, string nodeName)
    {
        yield return new WaitForSeconds(time);
        DialogueController.Instance.StartChat(nodeName);
    }
}

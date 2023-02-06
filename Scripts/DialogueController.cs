using System;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; }
    public TMP_InputField inputField;
    public GameObject decipher;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        runner.AddCommandHandler<string>("LoadScene", LoadScene);
        runner.AddCommandHandler("ActivateDecipher", ActivateDecipher);

    }
    [SerializeField] DialogueRunner runner;
    public RectTransform consoleView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ActivateDecipher()
    {
        decipher.SetActive(true);
    }
    public void StartChat(string nodeName)
    {
        consoleView.gameObject.SetActive(true);
        consoleView.localScale = Vector3.zero;
        consoleView.DOScale(1, 1f).From(0).onStepComplete
                = () => { runner.StartDialogue(nodeName); };
    }
    public void OpenWindow()
    {
        consoleView.gameObject.SetActive(true);
        consoleView.localScale = Vector3.zero;
        consoleView.DOScale(1, 1f).From(0);
    }
    public void Input()
    {
        inputField.gameObject.SetActive(true);
    }

}

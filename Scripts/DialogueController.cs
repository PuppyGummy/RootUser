using UnityEngine;
using Yarn.Unity;
using DG.Tweening;
using TMPro;
using Kino;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; }
    public TMP_InputField inputField;
    public GameObject decipher;
    public WindowUI myDocuments;
    public GameObject research, record, newsA, newsB;
    [SerializeField] DialogueRunner runner;
    public RectTransform consoleView;
    public InMemoryVariableStorage variableStorage;
    public AnalogGlitch analogGlitch;
    public DigitalGlitch digitalGlitch;
    public GameObject logoLayer, logoImage, logo, endLogo, escape, background;
    public Image desktop;
    public Sprite desktopEnd;
    public SceneTransition sceneTransition;
    private bool readSummon = false;
    private bool readResume = false;
    private bool visitedMyself = false;
    private bool readResearch = false;
    private bool readRecord = false;
    private bool readNewsA = false;
    private bool readNewsB = false;
    private bool visitedTruth = false;
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
        runner.AddCommandHandler("Input", ActivateInput);
        runner.AddCommandHandler("Sacrifice", Sacrifice);
        runner.AddCommandHandler("Escape", Escape);
    }

    private void Update()
    {
        if (inputField != null)
        {
            if (inputField.IsActive() && Input.GetKeyDown(KeyCode.Return))
            {
                VerifyInput();
            }
        }
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
        if (!consoleView.gameObject.activeSelf)
        {
            consoleView.gameObject.SetActive(true);
            consoleView.localScale = Vector3.zero;
            consoleView.DOScale(1, 1f).From(0).onStepComplete
                    = () => { runner.StartDialogue(nodeName); };
        }
        else
        {
            runner.StartDialogue(nodeName);
        }
    }
    public void OpenWindow()
    {
        if (!consoleView.gameObject.activeSelf)
        {
            consoleView.gameObject.SetActive(true);
            consoleView.localScale = Vector3.zero;
            consoleView.DOScale(1, 1f).From(0);
        }
    }
    public void ActivateInput()
    {
        inputField.text = "";
        inputField.gameObject.SetActive(true);
    }
    public void StartChatOnOpen()
    {
        if (readResume && readSummon && !visitedMyself && runner.CurrentNodeName != "Myself")
        {
            runner.StartDialogue("Myself");
            visitedMyself = true;
        }
        else if (readResearch && readRecord && readNewsA && readNewsB && !visitedTruth && runner.CurrentNodeName != "Truth")
        {
            analogGlitch.scanLineJitter = 0.175f;
            analogGlitch.colorDrift = 0.05f;
            digitalGlitch.intensity = 0.03f;
            runner.StartDialogue("Truth");
            visitedTruth = true;
        }
    }
    public void ReadResume()
    {
        readResume = true;
    }
    public void ReadSummon()
    {
        readSummon = true;
    }
    public void ReadResearch()
    {
        readResearch = true;
    }
    public void ReadRecord()
    {
        readRecord = true;
    }
    public void ReadNewsA()
    {
        readNewsA = true;
    }
    public void ReadNewsB()
    {
        readNewsB = true;
    }
    public void Sacrifice()
    {
        WindowUI[] windows = FindObjectsOfType<WindowUI>();
        foreach (WindowUI window in windows)
        {
            window.gameObject.SetActive(false);
        }
        logo.SetActive(false);
        endLogo.SetActive(true);
        desktop.sprite = desktopEnd;
    }
    public void Escape()
    {
        WindowUI[] windows = FindObjectsOfType<WindowUI>();
        foreach (WindowUI window in windows)
        {
            window.gameObject.SetActive(false);
        }
        logoLayer.SetActive(true);
        logoImage.SetActive(false);
        background.SetActive(true);
        escape.SetActive(true);
    }
    public void VerifyInput()
    {
        string s = inputField.text.Trim().ToLower();
        Debug.Log("Input: " + s);
        variableStorage.TryGetValue("$currentNode", out string currentNode);
        Debug.Log("Current Node: " + currentNode);
        if (currentNode == "Code")
        {
            if (s == "python3 code.py")
            {
                runner.StartDialogue("Compiled");
                inputField.gameObject.SetActive(false);
            }
            else
            {
                runner.StartDialogue("CommandNotFound");
                inputField.gameObject.SetActive(false);
            }
        }
        else if (currentNode == "Myself")
        {
            if (s == "sudo ls -a")
            {
                runner.StartDialogue("Password");
                inputField.gameObject.SetActive(false);
            }
            else
            {
                runner.StartDialogue("CommandNotFound");
                inputField.gameObject.SetActive(false);
            }
        }
        else if (currentNode == "Password")
        {
            if (s == "123abc")
            {
                research.SetActive(true);
                record.SetActive(true);
                newsA.SetActive(true);
                newsB.SetActive(true);
                inputField.gameObject.SetActive(false);
                runner.StartDialogue("CorrectPassword");
            }
            else
            {
                runner.StartDialogue("IncorrectPassword");
                inputField.gameObject.SetActive(false);
            }
        }
    }
}

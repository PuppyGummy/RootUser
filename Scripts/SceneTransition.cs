using UnityEngine;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup openingCanvasGroup, endCanvasgroup;
    public Animator openingAnimator, sacrificeAnimator, escapeAnimator;
    private bool openingAnimFinished, sacrificeAnimFinished, escapeAnimFinished;
    private bool openAnimSwitch = true;
    private bool sacrificeAnimSwitch = true;
    private bool escapeAnimSwitch = true;
    void Update()
    {
        openingAnimFinished = AnimFinished(openingAnimator);
        sacrificeAnimFinished = AnimFinished(sacrificeAnimator);
        escapeAnimFinished = AnimFinished(escapeAnimator);
        if (openingAnimFinished)
            OpenConsole();
        if (sacrificeAnimFinished)
            Sacrifice();
        else if (escapeAnimFinished)
            Escape();
    }
    private bool AnimFinished(Animator animator)
    {
        var animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        var NTime = animStateInfo.normalizedTime;
        if (NTime > 1.0f)
        {
            return true;
        }
        return false;
    }
    void OpenConsole()
    {
        if (openAnimSwitch)
        {
            openingCanvasGroup.DOFade(0, 3f).From(1).onStepComplete = () =>
            {
                openingCanvasGroup.gameObject.SetActive(false);
                DialogueController.Instance.StartChat("Hello");
            };
            openAnimSwitch = false;
        }
    }
    void Sacrifice()
    {
        if (sacrificeAnimSwitch)
        {
            sacrificeAnimSwitch = false;
            SwitchSceneToEnd("Sacrifice");
        }
    }
    void Escape()
    {
        if (escapeAnimSwitch)
        {
            escapeAnimSwitch = false;
            SwitchSceneToEnd("Escape");
        }
    }
    public void SwitchSceneToEnd(string sceneName)
    {
        endCanvasgroup.gameObject.SetActive(true);
        endCanvasgroup.DOFade(1, 3f).From(0).onStepComplete = () =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        };
    }
}

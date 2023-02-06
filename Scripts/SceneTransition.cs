using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Yarn.Unity;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Animator animator;
    private bool animFinished;
    private bool aniSwitch = true;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        var animStateInfo = animator.GetCurrentAnimatorStateInfo (0);
        var NTime = animStateInfo.normalizedTime;
 
        if(NTime > 1.0f){
           animFinished = true;
           OpenConsole();
        }
        
    }
    void OpenConsole()
    {
            if(animFinished && aniSwitch){

                Debug.Log("Animation finished");
                canvasGroup.DOFade(0, 5f).From(1).onStepComplete = () =>
                {
                    canvasGroup.gameObject.SetActive(false);
                    DialogueController.Instance.StartChat("Hello");
                };
                animFinished = false;
                aniSwitch = false;
            }
    }
}

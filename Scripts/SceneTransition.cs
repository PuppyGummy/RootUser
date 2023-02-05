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
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 5f).From(1).onStepComplete = () =>
        {
            canvasGroup.gameObject.SetActive(false);
            DialogueController.Instance.StartChat("Hello");
        };
    }
}

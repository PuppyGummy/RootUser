using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("canvasGroup.alpha: " + canvasGroup.alpha);
        canvasGroup.DOFade(0, 0.5f).From(1).onStepComplete = () => canvasGroup.gameObject.SetActive(false);
        Debug.Log("canvasGroup.alpha: " + canvasGroup.alpha);

    }
}

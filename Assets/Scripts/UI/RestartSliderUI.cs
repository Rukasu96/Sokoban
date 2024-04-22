using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartSliderUI : MonoBehaviour
{
    [SerializeField] private Slider circleSlider;
    private CanvasGroup canvasGroup;
    private bool isRestarting = false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SliderOn()
    {
        canvasGroup.DOFade(1f, 0.5f);
        circleSlider.value += Time.deltaTime;
    }

    public void SliderOff()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup.alpha <= 0)
            return;

        canvasGroup.DOFade(0f, 0.3f);
    }


}

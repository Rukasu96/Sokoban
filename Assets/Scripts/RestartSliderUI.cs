using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartSliderUI : MonoBehaviour
{
    [SerializeField] private Slider circleSlider;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsRestarting)
        {
            circleSlider.value = 0f;
            if(canvasGroup.alpha > 0)
            {
                canvasGroup.DOFade(0f, 0.3f);
            }
            return;
        }

        canvasGroup.DOFade(1f, 0.5f);
        circleSlider.value += Time.deltaTime;
        
    }
}

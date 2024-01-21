using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image crossFade;

    public float transitionTime = 1.0f;

    private void Start()
    {
        crossFade.DOFade(0, transitionTime);
    }

    public IEnumerator LoadCustomLevel(int sceneId)
    {
        yield return crossFade.DOFade(1, transitionTime).WaitForCompletion();
        SceneManager.LoadScene(sceneId);
    }

    
}

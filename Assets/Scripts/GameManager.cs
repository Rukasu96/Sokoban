using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelClearUI;
    private float elapsedTime;
    private bool isRestarting = false;

    public bool IsRestarting { get => isRestarting;}
    public int levelToUnlock;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartingRestart();
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            isRestarting = false;
            elapsedTime = 0f;
        }
    }
    private void StartingRestart()
    {
        isRestarting = true;
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2f)
        {
            SceneLoader sceneLoader = GetComponent<SceneLoader>();
            StartCoroutine(sceneLoader.LoadCustomLevel(SceneManager.GetActiveScene().buildIndex));
        }
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        levelClearUI.SetActive(true);
    }
}

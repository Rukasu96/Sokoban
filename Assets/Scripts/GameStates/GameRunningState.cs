using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunningState : GameBaseState
{
    float elapsedTime;

    public override void EnterState(GameManager gameState)
    {
    }

    public override void UpdateState(GameManager gameState)
    {
        if (Input.GetKey(KeyCode.R))
        {
            gameState.RestartSliderUI.SliderOn();
            StartingRestart(gameState.transform.gameObject);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            gameState.RestartSliderUI.SliderOff();
            elapsedTime = 0f;
        }
    }
    private void StartingRestart(GameObject gameObject)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2f)
        {
            SceneLoader sceneLoader = gameObject.GetComponent<SceneLoader>();
            sceneLoader.StartLoadingCustomLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


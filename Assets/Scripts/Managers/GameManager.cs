using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameBaseState currentState;
    public GameRunningState runningState = new GameRunningState();
    public GamePauseState pauseState = new GamePauseState();
    public GameFinishState finishState = new GameFinishState();

    [SerializeField] private GameObject levelClearUI;
    [SerializeField] private RestartSliderUI restartSliderUI;

    public GameObject LevelClearUI { get => levelClearUI; }
    public RestartSliderUI RestartSliderUI { get => restartSliderUI; }
    public GameBaseState CurrentState { get => currentState; }

    private void Start()
    {
        currentState = runningState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void CompleteLevel()
    {
        SwitchState(finishState);
    }

    private void SwitchState(GameBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnEnable()
    {
        Actions.CompleteLevel += CompleteLevel;
    }

}

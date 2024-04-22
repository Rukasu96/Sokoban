using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameFinishState : GameBaseState
{
    public override void EnterState(GameManager gameState)
    {
        int levelToUnlock = PlayerPrefs.GetInt("levelReached");
        levelToUnlock++;

        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        gameState.LevelClearUI.SetActive(true);
    }

    public override void UpdateState(GameManager gameState)
    {
    }
   
}

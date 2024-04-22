using Unity.VisualScripting;
using UnityEngine;

public abstract class GameBaseState
{
   public abstract void EnterState(GameManager gameState);
   public abstract void UpdateState(GameManager gameState);

}

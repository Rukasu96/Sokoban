using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : Player
{
    public Player player;

    private void Start()
    {
        SpawnManager.instance.AddClone(this);
    }

    private void Update()
    {
        if(player.Ismoving)
        {
            direction = -player.Direction;
            PrepareToMove(direction);
            movesCount--;
        }
    }
}

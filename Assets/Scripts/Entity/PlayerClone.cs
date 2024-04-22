using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : Entity
{
    private void Start()
    {
        targetPos = transform.position;
        Actions.AssignEntity(this);
    }

    public void MoveClone(Vector3 direction)
    {
        targetPos = transform.position - direction;
        Direction = -direction;

        if (Ismoving || !CanMove())
            return;

        Actions.AssignEntity(this);
        MakeMove(targetPos);
        targetPos = transform.position;
        Actions.RemoveEntity(this);

    }

    private void OnEnable()
    {
        Actions.MoveClone += MoveClone;
    }

}

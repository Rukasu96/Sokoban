using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : GridObject
{

    public override void Interact()
    {
        Vector3 moveDirection = Actions.GetTile(this).entity.Direction;

        targetPos = transform.position + moveDirection;
        transform.DOMove(targetPos, 0.2f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            targetPos = transform.position - moveDirection;
            Actions.RemoveFromTile(this);
            targetPos = transform.position;
            Actions.OnTileAction(this);
            Actions.AssignToTile(this);
        }
        );
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Entity : GridObject
{
    public Vector3 Direction;

    public float TimeToMove = 1f;
    public bool Ismoving = false;

    public bool CanMove()
    {
        Tile tile = Actions.GetTile(this);

        if (tile == null)
            return false;

        if (tile.IsBlocked || Ismoving)
            return false;

        if(tile.InteractableObject != null && tile.InteractableObject.IsMovable)
        {
            return CanMoveObject(tile.InteractableObject);
        }

        return true;
    }

    public void MakeMove(Vector3 targetPos)
    {
        Ismoving = true;
        Actions.OnTileAction(this);
        transform.DOMove(targetPos, 0.2f).SetEase(Ease.InOutSine).OnComplete(() => Ismoving = false);
        
    }

    private bool CanMoveObject(GridObject movableObject)
    {
        Tile nextTile = Actions.GetTile(movableObject);
        
        if (nextTile == null || nextTile.IsBlocked)
            return false;

        return true;
    }

}

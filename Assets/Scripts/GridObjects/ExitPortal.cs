using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : GridObject
{

    public override void Interact()
    {
        Tile tile = Actions.GetTile(this);

        if (!tile.entity.IsPlayer)
            return;

        Actions.CompleteLevel();
    }

}

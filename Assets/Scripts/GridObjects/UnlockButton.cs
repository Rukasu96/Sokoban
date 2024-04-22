using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : GridObject
{
    [SerializeField] private DoorTypes keyType;
    public bool IsClicked;

    private void TurnOff(Tile tile)
    {
        Tile tileToShutdown = Actions.GetTile(this);
        if (tile != tileToShutdown || !IsClicked ||
            (tile.InteractableObject != null))
            return;

        Actions.AssignToTile(this);
        Actions.CloseDoors(keyType);
        IsClicked = false;
    }

    public override void Interact()
    {
        if (IsClicked)
            return;

        IsClicked = true;
        Actions.RemoveFromTile(this);
        Actions.OpenDoors(keyType);

    }

    private void OnEnable()
    {
        Actions.TurnOffButton += TurnOff;
    }
}

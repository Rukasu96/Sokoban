using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    public static Action<GridObject> OnTileAction;
    public static Action<DoorTypes> OpenDoors;
    public static Action<DoorTypes> CloseDoors;
    public static Action<Tile> TurnOffButton;
    public static Action<GridObject> AssignToTile;
    public static Action<GridObject> RemoveFromTile;
    public static Action<Entity> AssignEntity;
    public static Action<Entity> RemoveEntity;
    public static Action CompleteLevel;
    public static Action PauseGame;
    public static Action<Vector3> MoveClone;
    public static Func<GridObject, Tile> GetTile;
}

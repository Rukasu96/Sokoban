using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private Transform tileParent;

    private Tile[][] tiles;

    public Tile[][] Tiles { get => tiles; }

    private void Awake()
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        tiles = new Tile[width][];
        for (int i = 0; i < width; i++)
        {
            tiles[i] = new Tile[height];
        }

        AssignTiles();
    }

    private void AssignTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            foreach (Transform tileChild in tileParent)
            {
                if ((int)tileChild.transform.position.x == i)
                {
                    Tile tile = new Tile()
                    {
                        InteractableObject = null,
                        IsBlocked = false,
                    };

                    tiles[i][(int)tileChild.transform.localPosition.z] = tile;
                }
            }

        }
    }
    public Tile ReturnTile(GridObject gridObjectRef)
    {
        int posX = (int)gridObjectRef.targetPos.x;
        int posZ = (int)gridObjectRef.targetPos.z;

        try
        {
            return tiles[posX][posZ];
        }
        catch(IndexOutOfRangeException)
        {
            return null;
        }
    }

    public void AssignEntityToTile(Entity entity)
    {
        Tile tile = ReturnTile(entity);
        tile.entity = entity;
    }

    public void RemoveEntityFromTile(Entity entity)
    {
        Tile tile = ReturnTile(entity);
        tile.entity = null;
        Actions.TurnOffButton(tile);
    }

    public void AssignInteractablesToTile(GridObject gridObjectRef)
    {
        Tile tile = ReturnTile(gridObjectRef);
        tile.InteractableObject = gridObjectRef;
    }

    public void RemoveInteractablesFromTile(GridObject gridObjectRef)
    {
        Tile tile = ReturnTile(gridObjectRef);
        tile.InteractableObject = null;
    }

    public void TileAction(GridObject gridObjectRef)
    {
        Tile tile = ReturnTile(gridObjectRef);
        GridObject tileObject = tile.InteractableObject;

        if (tileObject == null)
            return;

        tileObject.Interact();
        
    }

    private void OnEnable()
    {
        Actions.OnTileAction += TileAction;
        Actions.GetTile += ReturnTile;
        Actions.AssignEntity += AssignEntityToTile;
        Actions.RemoveEntity += RemoveEntityFromTile;
        Actions.AssignToTile += AssignInteractablesToTile;
        Actions.RemoveFromTile += RemoveInteractablesFromTile;
    }

}

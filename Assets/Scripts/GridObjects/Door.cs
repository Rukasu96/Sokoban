using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : GridObject
{
    [SerializeField] private DoorTypes doorTypes;
    [SerializeField] private int requireButtons;
    private int pushedButtons = 0;
    private Tile tile;
    public DoorTypes DoorTypes { get => doorTypes; }

    private void Start()
    {
        targetPos = transform.position;
        tile = Actions.GetTile(this);
        tile.IsBlocked = true;
    }

    public void AddPushedButton()
    {
        pushedButtons++;
        CheckPushedButtons();
    }

    public void RemovePushedButton()
    {
        pushedButtons--;
        CheckPushedButtons();
    }

    private void CheckPushedButtons()
    {
        if (pushedButtons >= requireButtons)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        tile.IsBlocked = false;
        gameObject.SetActive(false);
    }

    private void CloseDoor()
    {
        tile.IsBlocked = true;
        gameObject.SetActive(true);
    }
}

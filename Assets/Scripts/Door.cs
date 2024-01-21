using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorTypes doorTypes;
    [SerializeField] private int requireButtons;
    private int pushedButtons = 0;

    public DoorTypes DoorTypes { get => doorTypes; }
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
        gameObject.SetActive(false);
    }

    private void CloseDoor()
    {
        gameObject.SetActive(true);
    }
}

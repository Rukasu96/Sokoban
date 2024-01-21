using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    [SerializeField] private Door[] doors;

    public static DoorsManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MatchPushedButtonType(DoorTypes buttonType)
    {
        foreach (var door in doors)
        {
            if(door.DoorTypes == buttonType)
            {
                door.AddPushedButton();
            }
        }
    }

    public void MatchReleasedButtonType(DoorTypes buttonType)
    {
        foreach (var door in doors)
        {
            if (door.DoorTypes == buttonType)
            {
                door.RemovePushedButton();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    [SerializeField] private DoorTypes keyType;

    private void OnTriggerEnter(Collider other)
    {
        DoorsManager.Instance.MatchPushedButtonType(keyType);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorsManager.Instance.MatchReleasedButtonType(keyType);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public Vector3 targetPos;
    public bool IsMovable;
    public bool IsPlayer;

    private void Start()
    {
        targetPos = transform.position;
        Actions.AssignToTile(this);
    }

    public virtual void Interact() { }
}

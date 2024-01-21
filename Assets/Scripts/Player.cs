using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using UnityEngine;

public class Player : Entity
{
    public static int movesCount;
    public int strength;
    public Vector3 Direction { get => direction; }

    protected Vector3 direction;
    protected Crate crate;

    private void Start()
    {
        movesCount = 0;
        SpawnManager.instance.AddPlayer(this);
    }

    private void Update()
    {
        if (!Ismoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = Vector3.forward;
                PrepareToMove(direction);

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = Vector3.back;
                PrepareToMove(direction);

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector3.right;
                PrepareToMove(direction);

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector3.left;
                PrepareToMove(direction);

            }

        }

    }

    protected void PrepareToMove(Vector3 direction)
    {
        crate = GetCrate(direction);
        
        if (crate != null)
        {
            if (!CanMoveObject())
            {
                return;
            }

            PushObject(crate.gameObject);
        }
        movesCount++;

        MakeMove(direction);
    }

    protected void PushObject(GameObject objectToPush)
    {
        crate.MakeMove(direction);
    }

    protected Crate GetCrate(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 0.6f))
        {
            if (hit.transform.CompareTag("Movable"))
            {
                return hit.transform.GetComponent<Crate>();
            }
        }

        return null;
    }

    protected bool CanMoveObject()
    {
        if(strength < crate.requireStrength)
        {
            return false;
        }

        if (crate.IsPathBlocked(direction))
        {
            return false;
        }

        return true;
    }
}

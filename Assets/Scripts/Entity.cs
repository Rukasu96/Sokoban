using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Vector3 targetPos; 

    public float timeToMove = 1f;
    public bool Ismoving = false;

    public bool IsPathBlocked(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (hit.transform.CompareTag("Enviro"))
            {
                return true;
            }
        }
        return false;
    }

    public void MakeMove(Vector3 direction)
    {
        if (Ismoving)
        {
            return;
        }

        if (IsPathBlocked(direction))
        {
            return;
        }

        StartCoroutine(MoveEntity(direction));
    }

    IEnumerator MoveEntity(Vector3 direction)
    {
        Ismoving = true;
        float elapsedTime = 0f;
        targetPos = transform.position + (direction);

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Ismoving = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.transform.position.x == transform.position.x || other.transform.position.z == transform.position.z)
            {
                GameManager.Instance.CompleteLevel();
                Destroy(other.gameObject);
            }
        }
    }
    
}

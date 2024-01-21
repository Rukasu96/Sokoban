using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    
    public void SpawnObject()
    {
        Instantiate(prefabToSpawn, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }

}

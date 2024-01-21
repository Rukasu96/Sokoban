using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<PlayerClone> playerClones = new List<PlayerClone>();
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private Player player;

    public static SpawnManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            spawnPoint.SpawnObject();
        }
    }

    public void AddPlayer(Player player)
    {
        this.player = player;

        if(spawnPoints.Count - 1 == playerClones.Count)
        {
            AssignPlayerToClones();
        }
    }

    public void AddClone(PlayerClone clone)
    {
        playerClones.Add(clone);

        if(player != null && (spawnPoints.Count - 1 == playerClones.Count))
        {
            AssignPlayerToClones();
        }
    }

    private void AssignPlayerToClones()
    {
        foreach (PlayerClone clone in playerClones)
        {
            clone.player = player;
        }
    }
}

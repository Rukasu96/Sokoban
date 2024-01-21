using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingCalculator : MonoBehaviour
{
    [SerializeField] private int[] movesThresholds;
    
    public int GetRating()
    {
        int moves = Player.movesCount;

        for (int i = 0; i < movesThresholds.Length; i++)
        {
            if(moves <= movesThresholds[i])
            {
                return 3;
            }else if(moves > movesThresholds[i] && moves <= movesThresholds.Length)
            {
                return 2;
            }
        }

        return 1;
    }
}

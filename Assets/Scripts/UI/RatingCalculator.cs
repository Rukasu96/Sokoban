using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingCalculator : MonoBehaviour
{
    [SerializeField] private int[] movesThresholds;
    
    public int GetRating()
    {
        int moves = Player.movesCount;

        if (moves <= movesThresholds[0])
            return 3;
        else if (moves > movesThresholds[1] && moves <= movesThresholds[2])
            return 2;
        else
            return 1;

    }
}

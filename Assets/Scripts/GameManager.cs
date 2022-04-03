using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int bestScore;
    public int coin;
    
    void Start()
    {
        if (bestScore <= score)
        {
            bestScore = score;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameGod))]
public class RangeScoring : MonoBehaviour
{
    private static GameGod _gg;

    private void Start()
    {
        _gg = GetComponent<GameGod>();
    }

    public static void AddScore(int score)
    {
        _gg.AddScore(score);
    }
}

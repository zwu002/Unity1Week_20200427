using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static float bestTime = 999f;

    public static float BestTime { get => bestTime; set => bestTime = value; }
}

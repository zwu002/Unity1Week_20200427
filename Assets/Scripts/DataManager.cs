using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance = null;
    private static float bestTime = 999f;

    public static float BestTime { get => bestTime; set => bestTime = value; }



}

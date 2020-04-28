﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public int totalAnimalNumber;
    public int totalSpawnedNumber;
    public bool isCatSpawned = false;
    public bool spawnCat = false;

    public Spawner[] spawners;

    public int catSpawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        spawners = gameObject.GetComponentsInChildren<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            totalAnimalNumber += spawner.spawnNumberMax;
        }


        catSpawnIndex = (int)Random.Range(0, totalAnimalNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCatSpawned && totalSpawnedNumber >= catSpawnIndex)
        {
            spawnCat = true;
        }
    }
}

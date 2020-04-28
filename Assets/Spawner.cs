﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject neko;

    public Vector3 size;
    private Vector3 center;

    public Vector3 boxSize;
    public Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        center = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SpawnNeko();
        } 
    }

    public void SpawnNeko()
    {

        Vector3 spawnPos = center;
        bool canSpawnHere = false;
        int safetyNet = 0;

        while (!canSpawnHere)
        {
            float posX = Random.Range(-size.x / 2, size.x / 2);
            float posY = Random.Range(-size.y / 2, size.y / 2);

            spawnPos = center + new Vector3(posX, posY, posY);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }

            if (safetyNet > 50)
            {
                Debug.Log("can't spawn, while loop too many times!");
                break;
            }

            safetyNet++;
        }

        if (canSpawnHere)
        {
            Instantiate(neko, spawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawCube(center, size);
    }

    bool PreventSpawnOverlap (Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(gameObject.transform.position, boxSize, Quaternion.identity);

        for (int i = 0; i < colliders.Length; i++) 
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

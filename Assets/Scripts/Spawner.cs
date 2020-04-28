using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public CatSpawner catSpawner;
    public GameObject[] animal;

    public int spawnNumberMax;

    [SerializeField] private int currentSpawnNumber = 0;
    [SerializeField] private int actualSpawnNumber = 0;

    private bool isSpawnEnd = false;

    public Vector3 size;
    private Vector3 center;

    public float distanceControlX;
    public float distanceControlY;
    public Collider[] colliders;


    // Start is called before the first frame update
    void Start()
    {
        center = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (catSpawner.spawnCat)
        {
            SpawnCat();
            return;
        }


        if (currentSpawnNumber < spawnNumberMax)
        {
            SpawnAnimal();
            currentSpawnNumber++;
        } 
        else if (currentSpawnNumber == spawnNumberMax)
        {
            isSpawnEnd = true;
        }

        if (isSpawnEnd && !catSpawner.isCatSpawned)
        {
            SpawnCat();
        }
    }

    public void SpawnAnimal()
    {
        int currentAnimalIndex = (int)Random.Range(0, 5);

        Vector3 spawnPos = center;
        bool canSpawnHere = false;
        int safetyNet = 0;

        while (!canSpawnHere)
        {
            float posX = Random.Range(-size.x / 2, size.x / 2);
            float posY = Random.Range(-size.y / 2, size.y / 2);

            spawnPos = center + new Vector3(posX, posY, posY - transform.position.z);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }

            if (safetyNet > 20)
            {
                Debug.Log("can't spawn, while loop too many times!");
                break;
            }

            safetyNet++;
        }

        if (canSpawnHere)
        {
            Instantiate(animal[currentAnimalIndex], spawnPos, Quaternion.identity);
            actualSpawnNumber++;
            catSpawner.totalSpawnedNumber++;
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawCube(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), size);
    }

    bool PreventSpawnOverlap (Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(gameObject.transform.position, size, Quaternion.identity);

        for (int i = 0; i < colliders.Length; i++) 
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width - distanceControlX;
            float rightExtent = centerPoint.x + width + distanceControlX;
            float lowerExtent = centerPoint.y - height - distanceControlY;
            float upperExtent = centerPoint.y + height + distanceControlY;

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

    void SpawnCat()
    {
        int currentAnimalIndex = (int)Random.Range(0, 5);

        Vector3 spawnPos = center;
        bool canSpawnHere = false;
        int safetyNet = 0;

        while (!canSpawnHere)
        {
            float posX = Random.Range(-size.x / 2, size.x / 2);
            float posY = Random.Range(-size.y / 2, size.y / 2);

            spawnPos = center + new Vector3(posX, posY, posY - transform.position.z);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }

            if (safetyNet > 20)
            {
                Debug.Log("can't spawn, while loop too many times!");
                break;
            }

            safetyNet++;
        }

        if (canSpawnHere)
        {
            Instantiate(animal[5], spawnPos, Quaternion.identity);
            actualSpawnNumber++;
            catSpawner.totalSpawnedNumber++;
            catSpawner.isCatSpawned = true;
            catSpawner.spawnCat = false;
        }
    }
}

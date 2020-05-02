using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amimal_SelfKill : MonoBehaviour
{
    public float startRenderingTime = 0.1f;
    private float currentTime;
    private bool isRendered = false;

    void Start()
    {
        currentTime = Time.time;
    }


    void Update()
    {
        if (Time.time - currentTime >= startRenderingTime && !isRendered)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            isRendered = true;
        }


        if (GameManager.GetInstance().killingAnimals)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("NoSpawnZone"))
        {
            Debug.Log("This animal is in No Spawn Zone!");
            CatSpawner catSpawner = GetComponentInParent<CatSpawner>();

            catSpawner.totalSpawnedNumber--;

            Destroy(gameObject);
        }
    }
}

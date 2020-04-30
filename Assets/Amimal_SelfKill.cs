using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amimal_SelfKill : MonoBehaviour
{
    void Update()
    {
        if (GameManager.GetInstance().killingAnimals)
        {
            Destroy(gameObject);
        }
    }
}

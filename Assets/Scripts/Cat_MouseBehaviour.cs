using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_MouseBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    void OnMouseDown()
    {
        if (!GameManager.GetInstance().isCatFound)
        {
            Debug.Log("Cat clicked!");

            audioSource.Play();

            GameManager.GetInstance().CatFound();
        }
    }
}

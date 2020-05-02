using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_MouseBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public ParticleSystem particle;

    void OnMouseDown()
    {
        if (!GameManager.GetInstance().isCatFound && !GameManager.GetInstance().isPaused)
        {
            Debug.Log("Cat clicked!");

            audioSource.Play();

            particle.Play();

            GameManager.GetInstance().CatFound();
        }
    }
}

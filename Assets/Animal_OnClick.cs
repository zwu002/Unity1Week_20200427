using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_OnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public ParticleSystem particle;

    void OnMouseDown()
    {
        if (!GameManager.GetInstance().isCatFound && !GameManager.GetInstance().isPaused)
        {
            audioSource.Play();
            particle.Play();

            GameManager.GetInstance().timer.currentTime -= 0.5f;
        }
    }
}

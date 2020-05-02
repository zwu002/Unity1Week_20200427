using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_OnClick : MonoBehaviour
{
    public AudioSource audioSource;
    void OnMouseDown()
    {
        if (!GameManager.GetInstance().isCatFound && !GameManager.GetInstance().isPaused) audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_MouseBehaviour : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float minIdleTime;
    [SerializeField] private float maxIdleTime;

    private float timer;
    private float nextIdleTime;

    void Start ()
    {
        timer = Time.time;
        nextIdleTime = Random.Range(0, 3);
    }

    void Update ()
    {

        if (Time.time - timer >= nextIdleTime)
        {
            animator.SetTrigger("Idle");
            timer = Time.time;
            nextIdleTime = Random.Range(minIdleTime, maxIdleTime);
        }

    }

    void OnMouseEnter()
    {
        animator.SetBool("IsHover", true);
    }

    void OnMouseExit ()
    {
        animator.SetBool("IsHover", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_MouseBehaviour : MonoBehaviour
{
    public Animator animator;


    void OnMouseEnter()
    {
        animator.SetBool("IsHover", true);
    }

    void OnMouseExit ()
    {
        animator.SetBool("IsHover", false);
    }
}

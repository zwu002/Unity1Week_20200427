using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_MouseBehaviour : MonoBehaviour
{
    public Animator animator;


    void OnMouseEnter()
    {
        Debug.Log("Mouse entered!");
        animator.SetBool("IsHover", true);
    }

    void OnMouseExit ()
    {
        Debug.Log("Mouse exit!");
        animator.SetBool("IsHover", false);
    }
}

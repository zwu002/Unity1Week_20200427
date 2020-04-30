using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_MouseBehaviour : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("Cat clicked!");

        GameManager.GetInstance().CatFound();
    }
}

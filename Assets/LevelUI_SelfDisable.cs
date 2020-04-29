using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI_SelfDisable : MonoBehaviour
{

    [SerializeField] float selfDestroyTime = 3.5f;

    float initialTime;
    void Start()
    {
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initialTime >= selfDestroyTime)
        {
            GameManager.GetInstance().LevelBegin();

            gameObject.SetActive(false);
        }
    }
}

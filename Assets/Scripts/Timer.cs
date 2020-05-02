using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float currentLevelTime;
    public float currentTime;

    public Image foreground;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }


        foreground.fillAmount = currentTime / currentLevelTime;

        if (currentTime <=0 && !GameManager.GetInstance().isGameOver)
        {
            GameManager.GetInstance().StartCoroutine("GameOver");
        }
    }

    public void ResetTimer()
    {
        currentLevelTime = GameManager.GetInstance().levelTime[GameManager.GetInstance().currentLevel];
        currentTime = currentLevelTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] level;
    public GameObject[] levelUI;
    public float[] levelTime;

    public GameObject mainMenu;
    public GameObject mainHUD;
    public GameObject nextLevelUI;
    public GameObject levelLoadingUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public TextMeshProUGUI timeThisRound;
    public TextMeshProUGUI bestTime;

    public Timer timer;
    public float totalTime;

    public int currentLevel;
    public int totalLevel;
    public bool isCatFound;
    public bool isGameOver;

    static GameManager instance = null;

    public bool killingAnimals;

    void Awake()
    {
        Time.timeScale = 1;

        Debug.Log("Game Manager Awake");
        if (null == instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Destroy duplicate gm");
            Destroy(gameObject);
        }

        currentLevel = 0;
        totalTime = 0f;

        level[currentLevel].SetActive(true);

    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void CatFound()
    {
        Debug.Log("Cat Found!");

        if (currentLevel != 0)
        {
            RecordFinishedTime();
        }

        isCatFound = true;
        mainHUD.SetActive(false);

        currentLevel++;
        if (currentLevel < totalLevel)
        {
            Debug.Log("Next level Begin!");
            nextLevelUI.SetActive(true);
        }
        else
        {
            GameWin();
        }

    }

    public void GameWin()
    {
        Debug.Log("You Won!");

        gameWinUI.SetActive(true);

        RecordBestTime();

        KillAllAnimal();

        timeThisRound.text = (int)totalTime + "s";
        bestTime.text = (int)DataManager.BestTime + "s";
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        StartCoroutine(KillAllAnimal());

        mainHUD.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        StartCoroutine(Restart());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(KillAllAnimal());

        nextLevelUI.SetActive(false);

        levelUI[currentLevel-1].SetActive(false);    
        levelUI[currentLevel].SetActive(true);

        isCatFound = false;
    }

    public void LevelBegin()
    {
        mainHUD.SetActive(true);
        timer.ResetTimer();

        level[currentLevel].SetActive(true);
    }

    void RecordFinishedTime()
    {
        totalTime += levelTime[currentLevel] - timer.currentTime;
    }

    void RecordBestTime()
    {
        if (totalTime < DataManager.BestTime)
        {
            DataManager.BestTime = totalTime;
        }
    }

    IEnumerator KillAllAnimal()
    {
        yield return new WaitForSeconds(1f);
        killingAnimals = true;
        yield return new WaitForSeconds(0.1f);

        killingAnimals = false;

        foreach (GameObject level in level)
        {
            level.SetActive(false);
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Timer timer;

    public int currentLevel;
    public int totalLevel;
    public bool isCatFound;
    public bool isGameOver;

    static GameManager instance = null;

    public bool killingAnimals;

    void Awake()
    {
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

        level[currentLevel].SetActive(true);

    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void CatFound()
    {
        Debug.Log("Cat Found!");
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
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        ClearGameData();
        level[currentLevel].SetActive(true);
    }

    public void LoadNextLevel()
    {
        nextLevelUI.SetActive(false);
        levelUI[currentLevel-1].SetActive(false);
        levelUI[currentLevel].SetActive(true);
        level[currentLevel - 1].SetActive(false);

        StartCoroutine(KillAllAnimal());
    }

    public void LevelBegin()
    {
        mainHUD.SetActive(true);
        timer.ResetTimer();

        level[currentLevel].SetActive(true);
    }


    public void ClearGameData()
    {

    }

    IEnumerator KillAllAnimal()
    {
        killingAnimals = true;
        yield return new WaitForSeconds(1f);
        killingAnimals = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] level;
    public GameObject[] levelUI;

    public GameObject mainMenu;
    public GameObject mainHUD;
    public GameObject nextLevelUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public int currentLevel;
    public int totalLevel;
    public bool isCatFound;
    public bool isGameOver;

    static GameManager instance = null;

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

    public void NextLevelBegin()
    {
        nextLevelUI.SetActive(false);
        levelUI[currentLevel].SetActive(true);
    }

    public void ClearGameData()
    {

    }
}

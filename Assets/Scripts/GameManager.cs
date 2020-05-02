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
    public GameObject pauseUI;
    public TextMeshProUGUI timeThisRound;
    public TextMeshProUGUI bestTime;

    public Timer timer;
    public float totalTime;

    public int currentLevel;
    public int totalLevel;
    public bool isCatFound;
    public bool isGameOver;
    public bool isPaused;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();             
            }
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
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

    IEnumerator GameOver()
    {
        GameObject[] cat = GameObject.FindGameObjectsWithTag("Cat");

        if (cat.Length == 1)
            {
                 cat[0].GetComponent<Animal_MouseBehaviour>().animator.SetBool("IsHover", true);
                ParticleSystem[] particle = cat[0].GetComponentsInChildren<ParticleSystem>();

                if (particle.Length == 1)
                {
                    particle[0].Play();
                }
        }

        isGameOver = true;

        yield return new WaitForSeconds(1.5f);


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

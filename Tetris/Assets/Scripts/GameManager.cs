using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel, restartGamePanel;
    private SpawnBlocks instance;

    [SerializeField] private AudioSource music;

    private bool isGameActive = false; //булевая переменная, отвечает за начало/конец игры


    private void Awake()
    {
        instance = FindObjectOfType<SpawnBlocks>();
    }

    private void Start()
    {
        if (isGameActive)
        {
            StartGame();
        }
    }


    public void StartGame()
    {
        music.Play();
        menuPanel.SetActive(false);
        isGameActive = true;
        instance.NewBlock();
    }

    public void BackButton()
    {
        menuPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        music.Stop();
        isGameActive = false;
        Debug.Log("GameOver");
        restartGamePanel.SetActive(true);
    }
}

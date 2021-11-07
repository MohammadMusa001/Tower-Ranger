using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static bool isGameOver = false;
    [SerializeField]
    private GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if(isGameOver)
        {
            GameOver();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        isGameOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

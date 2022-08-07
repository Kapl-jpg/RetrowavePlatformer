using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausePanel != null)
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    /// <summary>
    /// Отменить паузу в игре
    /// </summary>
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Перезапустить уровень
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Выйти из игры
    /// </summary>
    public void ExitFromApplication()
    {
        print("exit");
        Application.Quit();
    }

    /// <summary>
    /// Загрузить сцену
    /// </summary>
    /// <param name="numberScene">Номер запускаемой сцены</param>
    public void LoadScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}

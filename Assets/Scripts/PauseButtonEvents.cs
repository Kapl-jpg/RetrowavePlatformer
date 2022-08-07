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
    /// �������� ����� � ����
    /// </summary>
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// ������������� �������
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void ExitFromApplication()
    {
        print("exit");
        Application.Quit();
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="numberScene">����� ����������� �����</param>
    public void LoadScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public TextMeshProUGUI highlightedButton;
    public GameObject pauseMenuUI;
    public bool GameIsPaused = false;

    public void PaintItWhite()
    {
        highlightedButton.color = Color.white;
    }      

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PaintItWhite();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Scene");
        Time.timeScale = 1f;
        PaintItWhite();
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}

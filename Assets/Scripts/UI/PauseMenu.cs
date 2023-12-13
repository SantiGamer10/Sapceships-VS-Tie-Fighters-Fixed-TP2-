using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private string buttonToMenu = "Level name";

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        levelMusic.Pause();
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        levelMusic.Play();
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(buttonToMenu);
        Time.timeScale = 1f;
    }
}

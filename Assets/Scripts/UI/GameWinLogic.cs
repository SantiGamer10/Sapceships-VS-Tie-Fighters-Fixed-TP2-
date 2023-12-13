using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinLogic : MonoBehaviour
{
    [SerializeField] private GameObject gameWinningMenu;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource WinningMusic;
    [SerializeField] private int remainingAsteroids;
    [SerializeField] private string buttonToMenu = "add level name here";

    private void Update()
    {
        EndLevel();
    }
    public void ReturnButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(buttonToMenu);
    }

    public void EndLevel()
    {
        if (remainingAsteroids <= 0)
        {
            gameWinningMenu.SetActive(true);
            levelMusic.Pause();
        }
    }
}

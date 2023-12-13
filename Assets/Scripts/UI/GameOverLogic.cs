using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource loseMusic;
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private string buttonToMenu = "Level name";


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
        if (healthPoints.HP <= 0)
        {
            gameOverMenu.SetActive(true);
            levelMusic.Pause();
        }
    }
}

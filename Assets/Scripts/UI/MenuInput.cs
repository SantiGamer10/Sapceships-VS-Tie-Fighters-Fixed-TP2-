using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private string startButton = "Level name";

    public void StartButton()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene(startButton);
    }

    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        MainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}

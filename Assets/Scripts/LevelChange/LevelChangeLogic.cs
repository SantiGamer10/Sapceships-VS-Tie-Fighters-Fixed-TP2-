using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeLogic : MonoBehaviour
{
    [SerializeField] private string sceneName = "Level name";


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

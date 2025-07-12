using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void GameOver()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void DisplayScore()
    {
    SceneManager.LoadScene("StartMenu");
    }
}

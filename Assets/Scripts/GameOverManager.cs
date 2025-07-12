using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void OnClickYes()
    {
        // Load the GameMenu scene
        SceneManager.LoadScene("GameMenu");
    }

    public void OnClickNo()
    {
        // Save the score before loading the DisplayScore scene
        if (UIManager.Instance != null)
        {
            PlayerPrefs.SetInt("FinalScore", UIManager.Instance.GetScore());
        }

        SceneManager.LoadScene("DisplayScore");
    }
}

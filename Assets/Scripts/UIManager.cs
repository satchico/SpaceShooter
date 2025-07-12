using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public int lives = 3;
    public int score = 0;

    public TMPro.TMP_Text livesText;
    public TMPro.TMP_Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            // Save the score before switching scenes
            PlayerPrefs.SetInt("FinalScore", score);

            // Load GameOver Scene
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Respawn player
            if (PlayerController.Instance != null)
                PlayerController.Instance.Respawn();
        }
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    // Optional: Reset when starting new game
    public void ResetStats()
    {
        lives = 3;
        score = 0;
        UpdateUI();
    }
}



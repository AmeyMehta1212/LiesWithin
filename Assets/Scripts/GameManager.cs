using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private int highScore = 0;
    private bool gameStarted = false;
    private bool gameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        Time.timeScale = 0f; // Pause game until started
        UIManager.Instance?.ShowStartScreen(); // Show your title or start UI
    }

    public void StartGame()
    {
        Debug.Log("StartGame called!");

        gameStarted = true;
        gameOver = false;
        score = 0;
        Time.timeScale = 1f;

        Debug.Log("Time.timeScale set to 1");

        UIManager.Instance?.HideStartScreen();
        UIManager.Instance?.UpdateScoreUI(score, highScore);
    }


    public void AddScore(int value)
    {
        if (!gameStarted || gameOver) return;

        score += value;
        UIManager.Instance?.UpdateScoreUI(score, highScore);
    }

    public void GameOver()
    {
        if (gameOver) return;

        gameOver = true;
        Time.timeScale = 0f;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UIManager.Instance?.ShowGameOverScreen();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public int GetScore()
    {
        return score;
    }
}

  
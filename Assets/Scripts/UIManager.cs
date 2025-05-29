using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI")]
    public GameObject interactionPanel;
    public Button fakeButton;
    public Button realButton;
    public TMP_Text feedbackText;

    [Header("Game Control Buttons")]
    public Button restartButton;
    public Button exitButton;

    [Header("Game State Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;

    [Header("Score Text")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private LieMarker currentMarker;

    void Awake()
    {
        Instance = this;

        interactionPanel.SetActive(false);
        gameOverPanel?.SetActive(false);
        startPanel?.SetActive(true);

        fakeButton.onClick.AddListener(() => OnPlayerChoice(true));
        realButton.onClick.AddListener(() => OnPlayerChoice(false));

        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void ShowInteractionPrompt(LieMarker marker)
    {
        currentMarker = marker;
        interactionPanel.SetActive(true);
        feedbackText.text = "Is this object Fake or Real?";
    }

    private void OnPlayerChoice(bool choseFake)
    {
        bool correct = currentMarker.IsLie() == choseFake;

        if (correct)
        {
            Object.FindAnyObjectByType<JournalManager>()?.LogMessage(currentMarker.name + " was correctly identified.");
            currentMarker.MarkAsChecked();
        }
        else
        {
            GameManager.Instance?.GameOver();
        }

        interactionPanel.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Debug.Log("Exiting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 🎮 Game State UI Methods

    public void ShowStartScreen()
    {
        if (startPanel != null)
            startPanel.SetActive(true);
    }

    public void HideStartScreen()
    {
        if (startPanel != null)
            startPanel.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void UpdateScoreUI(int score, int highScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }
}

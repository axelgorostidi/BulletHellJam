using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimeText;
    [SerializeField] private TextMeshProUGUI enemiesDestroyedText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button mainMenuButton;


    private void Start() 
    {
        resetButton.onClick.AddListener(GameController.instance.ResetGame);
        mainMenuButton.onClick.AddListener(GameController.instance.GoToMainMenu);
        UpdateUI();
    }

    public void UpdateUI()
    {
        gameTimeText.SetText(TextController.GameOverUIGameTime());
        enemiesDestroyedText.SetText(TextController.GameOverUIEnemiesDestroyed());
        scoreText.SetText(TextController.GameOverScoreText());
    }
}

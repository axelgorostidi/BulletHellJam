using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;


    private void Start() 
    {
        startButton.onClick.AddListener(GameController.instance.ResetGame);
        exitButton.onClick.AddListener(GameController.instance.ExitGame);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    private float currentGameTime;
    private int enemiesDestroyed;
    private bool isPlaying;

    public enum TextLanguage
    {
        Spanish,
        English
    };
    public TextLanguage textLanguage;


    private void Awake() {
        if(instance==null)
            instance=this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    private void Start() {
        textLanguage = TextLanguage.Spanish;
        isPlaying = false;
        enemiesDestroyed = 0;
        currentGameTime = 0f;
    }

    private void Update() 
    {
        if(!isPlaying)
            return;

        if(UIController.instance==null)
            return;
            
        currentGameTime += Time.deltaTime;
        UIController.instance.UpdateGameTime(currentGameTime);
    }

    public void AddEnemyDestroyed()
    {
        enemiesDestroyed++;
        UIController.instance.UpdateEnemiesDestroyed(enemiesDestroyed);
    }

    public void ResetGame()
    {
        isPlaying = true;
        enemiesDestroyed = 0;
        currentGameTime = 0f;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        //SALIR
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void SetGameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public float GetCurrentGameTime()
    {
        return currentGameTime;
    }

    public int GetEnemiesDestroyed()
    {
        return enemiesDestroyed;
    }

}

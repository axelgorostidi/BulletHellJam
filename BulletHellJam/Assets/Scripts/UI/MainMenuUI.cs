using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    private float timer = 0f;
    private float aux = 0.001f;
    [SerializeField] private TextMeshProUGUI tecnometry;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI userNameText;

    [Header("Set User Name")]
    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TextMeshProUGUI userNameErrorText;
    [SerializeField] private Button saveUserNameButton;

    [Header("Scoreboard")]
    [SerializeField] private GameObject scoreboard;

    [Header("Tutorial")]
    [SerializeField] private GameObject canvasTutorial;
    [SerializeField] private GameObject tutorialImageSpanish;
    [SerializeField] private GameObject tutorialImageEnglish;


    private void Start() 
    {
        startButton.onClick.AddListener(GameController.instance.ResetGame);
        exitButton.onClick.AddListener(GameController.instance.ExitGame);

        userNameErrorText.SetText(TextController.UserNameError());
        userNameErrorText.gameObject.SetActive(false);
        
        highScoreText.text = TextController.HighScoreText(PlayerPrefs.GetInt("HighScore", 0));

        string user = PlayerPrefs.GetString("UserName", "");
        if(user == "")
        {
            SetActiveUserNameUI(true);
        }
        else
        {
            GameController.instance.userName = user;
            userNameText.SetText(user);
            SetActiveUserNameUI(false);
        }
    }

    private void Update(){
        timer += Time.deltaTime;
        tecnometry.transform.localScale = new Vector3(tecnometry.transform.localScale.x+aux,tecnometry.transform.localScale.y+aux,1);
        if(timer >= 5f){
            
            //float rand = UnityEngine.Random.Range(0f, 100f);
            //tecnometry.color = new Color(255,0,rand,255);
            aux *= -1;
            timer = 0f;
        }
        
        

        //Debug.Log(timer);
    }

    public void SaveUserName()
    {
        Debug.Log("USER: " + userNameInputField.text);
        if(IsUserNameValid())
        {
            SetActiveUserNameUI(false);

            userNameText.SetText(userNameInputField.text);
            PlayerPrefs.SetString("UserName", userNameInputField.text);
            GameController.instance.userName = userNameInputField.text;
            userNameErrorText.gameObject.SetActive(false);
        }
        else
        {
            userNameErrorText.gameObject.SetActive(true);
        }
    }

    private bool IsUserNameValid()
    {
        string user = userNameInputField.text;

        if(user=="" || user.Contains("*") || user.Length > 10)
            return false;

        // PROFANITY CHECK

        return true;
    }

    private void SetActiveUserNameUI(bool aux)
    {
        // TODO LO QUE ESTÁ ACTIVADO AL PONER NOMBRE DE USUARIO
        userNameInputField.gameObject.SetActive(aux);
        saveUserNameButton.gameObject.SetActive(aux);

        // TODO LO QUE SE ACTIVA UNA VEZ SETEADO EL NOMBRE
        userNameText.gameObject.SetActive(!aux);
        highScoreText.gameObject.SetActive(!aux);
        startButton.gameObject.SetActive(!aux);
        exitButton.gameObject.SetActive(!aux);
        scoreboard.gameObject.SetActive(!aux);
        tutorialButton.gameObject.SetActive(!aux);
    }

    public void UpdateUI()
    {
        highScoreText.SetText(TextController.HighScoreText(PlayerPrefs.GetInt("HighScore", 0)));
        userNameErrorText.SetText(TextController.UserNameError());
    }

    public void ShowTutorial()
    {
        canvasTutorial.SetActive(true);
        
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
        {
            tutorialImageSpanish.SetActive(true);
            tutorialImageEnglish.SetActive(false);
        }
        else
        {
            tutorialImageSpanish.SetActive(false);
            tutorialImageEnglish.SetActive(true);
        }
    }
}

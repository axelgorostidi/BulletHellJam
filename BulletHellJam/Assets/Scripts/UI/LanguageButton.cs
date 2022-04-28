using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] private GameController.TextLanguage language;

    private void Start() 
    {
        Button button = GetComponent<Button>();
        if(button==null)
            Debug.LogWarning("Hay algún objeto con el script LanguageButton, pero este objeto no es un botón, debería serlo");
        else
            button.onClick.AddListener(ChangeLanguage);
    }

    private void ChangeLanguage()
    {
        GameController.instance.SetLanguageTo(language);
    }
}

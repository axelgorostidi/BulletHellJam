using UnityEngine;
using TMPro;

public class LanguageText : MonoBehaviour
{
    [SerializeField] private string textSpanish;
    [SerializeField] private string textEnglish;
    [SerializeField] private TextMeshProUGUI textObject;

    
    void FixedUpdate()
    {
        if(GameController.instance.textLanguage == GameController.TextLanguage.Spanish)
        {
            textObject.SetText(textSpanish);
        }    
        else
        {
            textObject.SetText(textEnglish);
        }
    }
}

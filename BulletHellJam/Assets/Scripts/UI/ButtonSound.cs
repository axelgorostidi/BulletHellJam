using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private void Start() 
    {
        Button button = GetComponent<Button>();
        if(button==null)
            Debug.LogWarning("Hay algún objeto con el script ButtonSound, pero este objeto no es un botón, debería serlo si queres que tenga sonido");
        else
            button.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
}

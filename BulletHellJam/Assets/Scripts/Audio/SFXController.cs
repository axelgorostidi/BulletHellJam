using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    Slider slider;

    private void Start() 
    {
        slider = GetComponent<Slider>();
        if(slider==null)
            Debug.LogWarning("Hay un objeto con el script SFXController pero no es un slider, debería serlo");
        else
        {
            slider.value = AudioManager.instance.volumeSFX;
            slider.onValueChanged.AddListener(ChangeSFXVolume);
        }
    }

    private void ChangeSFXVolume(float value)
    {
        AudioManager.instance.volumeSFX = slider.value;
    }

}

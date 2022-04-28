using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    Slider slider;

    private void Start() 
    {
        slider = GetComponent<Slider>();
        if(slider==null)
            Debug.LogWarning("Hay un objeto con el script MusicController pero no es un slider, debería serlo");
        else
        {
            slider.value = AudioManager.instance.volumeMusic;
            slider.onValueChanged.AddListener(ChangeMusicVolume);
        }
    }

    private void ChangeMusicVolume(float value)
    {
        AudioManager.instance.ChangeMusicVolume(slider.value);
    }
}

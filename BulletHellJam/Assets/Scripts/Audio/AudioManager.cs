using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [Range(0f,1f)] public float volumeMusic = 0.5f;
    [Range(0f,1f)] public float volumeSFX = 0.5f;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip gameOverMusic;

    [Header("UI")]
    public AudioClip buttonClick;

    [Header("Player")]
    public AudioClip playerProjectiles;
    public AudioClip playerShield;
    public AudioClip playerDamaged;
    public AudioClip playerDestroyed;

    [Header("Enemies")]
    public AudioClip enemyProjectile;
    public AudioClip enemyTeleport;
    public AudioClip enemyDamaged;
    public AudioClip enemyDestroyed;


    private void Awake() 
    {
        if(instance==null)
            instance=this;
        else
            Destroy(this.gameObject);
         
        DontDestroyOnLoad(this);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = volumeMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.loop = false;
        sfxSource.volume = volumeSFX;
        sfxSource.Play();
    }

    public void ChangeMusicVolume(float value)
    {
        musicSource.volume = value;
        volumeMusic = value;
    }
}

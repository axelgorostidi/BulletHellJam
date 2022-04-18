using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    static public SceneController instance = null;

    [SerializeField] private Animator animator;
    [SerializeField] private Image faddingImage;
    [SerializeField] private float faddingTime = 1.5f;

    private void Awake() 
    {
        if(instance==null)
            instance=this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }


    private void Start() 
    {
        faddingImage.color = new Color(0f, 0f, 0f, 0f);    
    }

    public void LoadNewScene(string sceneName, LoadSceneMode mode)
    {
        StartCoroutine(FadeScene(sceneName, mode));
    }


    IEnumerator FadeScene(string sceneName, LoadSceneMode mode)
    {
        animator.SetBool("fadding", true);

        yield return new WaitForSeconds(faddingTime);

        SceneManager.LoadScene(sceneName, mode);
        animator.SetBool("fadding", false);
    }

}

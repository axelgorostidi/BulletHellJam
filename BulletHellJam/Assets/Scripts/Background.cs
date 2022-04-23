using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour
{
    [SerializeField] List<Sprite> textures;

    [SerializeField] private float timeBtwTexture = .5f;
    private float currentTime = 0f;

    private int currentIndx;
    private Image image;

    private void Start() 
    {
        image = GetComponent<Image>();
        currentIndx = Random.Range(0,4);
    }

    private void FixedUpdate() 
    {
        currentTime += Time.fixedDeltaTime;
        if(currentTime>=timeBtwTexture)
        {
            ChangeTexture();
            currentTime = 0f;
        }
    }

    private void ChangeTexture()
    {
        currentIndx += 1;
        image.sprite = textures[(int)currentIndx%4];
    }
}

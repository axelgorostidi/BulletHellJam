using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] List<Sprite> textures;

    [SerializeField] private float timeBtwTexture = .5f;
    private float currentTime = 0f;

    private int currentIndx;

    private void Start() {
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
        spriteRenderer.sprite = textures[(int)currentIndx%4];
    }
}

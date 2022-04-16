using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBasicController : MonoBehaviour
{
    public float speedBullet = 6f;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += transform.right * (speedBullet * Time.deltaTime);
        
        //new Vector3(0f, (speedBullet * Time.deltaTime), 0f);
        Destroy(gameObject, 5f);
    }

    public void setDirection(Vector2 dir){
        transform.right = dir;
    }

}

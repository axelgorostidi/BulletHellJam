using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBasicController : Bullet
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
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject, 0f);
        }
    }
}

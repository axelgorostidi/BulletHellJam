using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : Bullet
{
    public float speedBullet = 6f;
    private Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * (speedBullet * Time.deltaTime);  

        if(Base.instance.CheckCollision(transform.position, hitboxRadius)) //vemos las colisiones con el jugador
        {
            Base.instance.Damage(damageAmount, gameObject);
        }

        Destroy(gameObject, 5f);
    }

    protected void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, hitboxRadius);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject, 0f);
        }
    }

}

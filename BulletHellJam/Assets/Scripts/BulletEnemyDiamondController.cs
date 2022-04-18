using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDiamondController : Bullet
{
    [SerializeField] float speedBullet = 6f;
    [SerializeField] GameObject center;
    private Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        center = GameObject.FindGameObjectWithTag("base");
        //float randX = UnityEngine.Random.Range(-400f, 400f);
        //float randY = UnityEngine.Random.Range(-400f, 400f);
        //rb.AddForce(new Vector2(randX,randY));
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 move = (center.transform.position - transform.position).normalized;
        transform.position += transform.right * (speedBullet * Time.deltaTime)*2f;  

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

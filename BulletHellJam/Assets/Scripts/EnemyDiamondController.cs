using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiamondController : Enemy
{
    
    [SerializeField] GameObject center;
    [SerializeField] GameObject BulletEnemyShoot;
    [SerializeField] float MinDistance = 3f;
    [SerializeField] float MaxDistance = 4.5f;
    private float timerToShoot = 0f;
    [SerializeField] float timeToShoot = 1f;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("base");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        timerToShoot += Time.deltaTime;
        if(timeToShoot <= timerToShoot){
            timerToShoot = 0f;
            ShootController();
        }
        teleportController();

        if (spriteRenderer.color != originalColor)
        {
            manageColorDamage();
        }
    }

    void teleportController(){
        float randX = UnityEngine.Random.Range(center.transform.position.x-90f, center.transform.position.x+90f);
        float randY = UnityEngine.Random.Range(center.transform.position.y-50f, center.transform.position.x+50f);
        Vector3 randPos = new Vector3(randX, randY,0);
        if((randPos - center.transform.position).magnitude >= MinDistance && (randPos - center.transform.position).magnitude <= MaxDistance){
            transform.position = randPos;
        }
    }
    void ShootController(){
        if((transform.position - center.transform.position).magnitude <= MaxDistance){
            float rand = UnityEngine.Random.Range(0f, 100f);
            if(rand <= 50f){
                GameObject bullet = Instantiate(BulletEnemyShoot, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletEnemyController>().setDirection((center.transform.position-transform.position).normalized);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bullet")
        {
            Damage();
        }
    }
}

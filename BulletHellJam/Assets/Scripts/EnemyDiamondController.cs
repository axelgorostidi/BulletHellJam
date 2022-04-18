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

    [Header("Particles")]
    [SerializeField] private GameObject particleTeleportingAway;
    [SerializeField] private GameObject particleTeleportingIn;


    void Start()
    {
        center = GameObject.FindGameObjectWithTag("base");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        randomForce(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,2),Space.Self);
        timerToShoot += Time.deltaTime;
        if(timeToShoot <= timerToShoot){
            timerToShoot = 0f;
            ShootController();
        }
         if((transform.position - center.transform.position).magnitude<=MinDistance || (transform.position - center.transform.position).magnitude>=MaxDistance){
            teleportController(1);
        }else{
            teleportController(0);
        }
        
        randomForce(0);

        if (spriteRenderer.color != originalColor)
        {
            manageColorDamage();
        }
    }

    void randomForce(int forceRand){
        float rand = UnityEngine.Random.Range(0f, 100f);
        if(rand<=10f || forceRand == 1){
            float randX = UnityEngine.Random.Range(-5f,5f);
            float randY = UnityEngine.Random.Range(-5f,5f);
            rb.AddForce(new Vector2(randX,randY));
        }

    }

    void teleportController(int forceTeleport){
        int successTeleport = 0;
        while (successTeleport != 1)
        {
            if(forceTeleport == 0){
                successTeleport = 1;
            }
            float randX = UnityEngine.Random.Range(center.transform.position.x-90f, center.transform.position.x+90f);
            float randY = UnityEngine.Random.Range(center.transform.position.y-50f, center.transform.position.x+50f);
            Vector3 randPos = new Vector3(randX, randY,0);
            if((randPos - center.transform.position).magnitude >= MinDistance && (randPos - center.transform.position).magnitude <= MaxDistance){
                Instantiate(particleTeleportingAway, transform.position, Quaternion.identity);
                Instantiate(particleTeleportingIn, randPos, Quaternion.identity);
                transform.position = randPos;
                successTeleport = 1;
            }
        }
    }
    void ShootController(){
        if((transform.position - center.transform.position).magnitude <= MaxDistance){
            float rand = UnityEngine.Random.Range(0f, 100f);
            if(rand <= 50f){
                GameObject bullet = Instantiate(BulletEnemyShoot, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletEnemyDiamondController>().setDirection((center.transform.position-transform.position).normalized);
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

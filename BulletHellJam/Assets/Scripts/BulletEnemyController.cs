using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
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
        //new Vector3(0f, (speedBullet * Time.deltaTime), 0f);
        Destroy(gameObject, 5f);
    }

    public void setDirection(Vector2 dir){
        transform.right = dir;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject, 0f);
        }
    }

}

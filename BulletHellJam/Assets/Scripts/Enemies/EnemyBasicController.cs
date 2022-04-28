using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicController : Enemy
{
    [SerializeField] GameObject center;
    
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("base");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        move = (center.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(move.x * speed * Time.deltaTime, move.y * speed * Time.deltaTime, 0f);
        if (spriteRenderer.color != originalColor)
        {
            manageColorDamage();
        }
        checkCollisionWhithPlayer();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bullet")
        {
            Damage();
        }
    }
}

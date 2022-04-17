using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicController : MonoBehaviour
{
    [SerializeField] GameObject center;
    
    private Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    private Vector2 move;
    [SerializeField] float life;
    private Color originalColor;
    [SerializeField] Color damageColor;
    private SpriteRenderer spriteRenderer;
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
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bullet")
        {
            GameController.instance.AddEnemyDestroyed();
            Destroy(gameObject, 0f);
        }
    }
}

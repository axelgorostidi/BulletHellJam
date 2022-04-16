using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float speedShield = 6f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moving == true){
            transform.position += new Vector3(direction.x, direction.y, 0f)  * (speedShield * Time.deltaTime);
        }
        Destroy(gameObject, 5f);
    }

    public void setMoving(bool aux){
        moving = aux;
    }

    public void setDirection(Vector2 dir){
        direction = dir;
    }
}

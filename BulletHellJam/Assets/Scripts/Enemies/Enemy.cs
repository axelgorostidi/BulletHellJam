using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 1;
    protected Rigidbody2D rb;
    public float speed = 2f;
    protected Vector2 move;
    public int life = 5;
    public float hitboxRadius = 1f;
    //Sprite
    protected SpriteRenderer spriteRenderer;
    protected Color originalColor;
    public Color damageColor;
    public float colorTime;
    public float currentColorTime;


    protected void Damage(){
        life -= 1;
        spriteRenderer.color = damageColor;
        currentColorTime = colorTime;
        if(life <= 0f){
            GameController.instance.AddEnemyDestroyed();
            AudioManager.instance.PlaySFX(AudioManager.instance.enemyDestroyed);

            if(this.GetComponent<EnemyBasicController>()!=null && DrawLimit.instance!=null)
                DrawLimit.instance.IncreaseScale();
                
            Destroy(gameObject, 0f);
        }

        AudioManager.instance.PlaySFX(AudioManager.instance.enemyDamaged);
    }

    protected void manageColorDamage()
    {
        if (currentColorTime > 0) {
                currentColorTime -= Time.deltaTime;
        }else{
                spriteRenderer.color = originalColor;
        }
    }

    protected void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, hitboxRadius);
    }

    protected void checkCollisionWhithPlayer(){
        
        if(Base.instance.CheckCollision(transform.position, hitboxRadius))
        {
            Base.instance.Damage(damageAmount, gameObject);
        }
    }

}

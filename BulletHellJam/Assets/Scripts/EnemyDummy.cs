using UnityEngine;

public class EnemyDummy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float hitboxRadius = 1f;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private int maxHP = 5;
    private int currentHP;

    private void Start() {
        currentHP = maxHP;
    }

    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0f, 0f);
        if(Base.instance.CheckCollision(transform.position, hitboxRadius))
        {
            Base.instance.Damage(damageAmount);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, hitboxRadius);
    }

    public void Damage(int amount)
    {
        currentHP -= amount;
        if(currentHP<=0)
        {
            GameController.instance.AddEnemyDestroyed();
            Destroy(this.gameObject);
        }
    }
}

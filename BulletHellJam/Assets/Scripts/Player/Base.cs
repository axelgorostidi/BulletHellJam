using UnityEngine;
using EZCameraShake;

public class Base : MonoBehaviour
{
    public static Base instance = null;
    [SerializeField] private int maxHP = 10;
    private int currentHP = 0;

    [SerializeField] private float hitboxRadius = 5f;


    private void Awake() 
    {
        if(instance==null)
            instance=this;
        else
            Destroy(this.gameObject);
    }

    private void Start() 
    {
        currentHP = maxHP;
        UIController.instance.UpdateBaseHP(currentHP, maxHP);
    }

    public void Damage(int amount, GameObject go)
    {
        CameraShaker.Instance.ShakeOnce(1f, 4f, 1f, 1f);

        currentHP -= amount;
        
        if(go!=null)
            Destroy(go, 0f);

        if(currentHP <= 0)
        {
            currentHP = 0;
            UIController.instance.UpdateBaseHP(currentHP, maxHP);
            AudioManager.instance.PlaySFX(AudioManager.instance.playerDestroyed);
            GameController.instance.SetGameOver();
        }
        else
        {
            UIController.instance.UpdateBaseHP(currentHP, maxHP);
            AudioManager.instance.PlaySFX(AudioManager.instance.playerDamaged);
        }        
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, hitboxRadius);    
    }

    public bool CheckCollision(Vector3 pos, float hbRadius)
    {
        float distBtwCenters = Vector3.Distance(transform.position, pos);

        if(distBtwCenters < (hitboxRadius+hbRadius))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

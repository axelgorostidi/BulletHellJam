using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAbility : Ability
{
    [Header("Properties")]
    [SerializeField] private int bulletAmount = 100;
    
    [Header("UI")]
    [SerializeField] private Bullet bulletPrefab;


    public override void UseAbility()
    {
        float deltaAngle = 360f / bulletAmount;
        float currentAngle = 0f;

        for (int i = 0; i < bulletAmount; i++)
        {
            Bullet bulletGO = Instantiate(bulletPrefab, Base.instance.transform.position, Quaternion.identity);
            
            bulletGO.transform.Rotate(Vector3.forward, currentAngle);

            currentAngle += deltaAngle;
        }

        base.UseAbility();
    }
}

using System.Collections;
using UnityEngine;

public class LaserAbility : Ability
{
    [Header("Properties")]
    [SerializeField] private float laserTime = 5f;
    private float currentLaserTime = 0f;
    [SerializeField] private float timeBtwBullet = .1f;

    [Header("UI")]
    [SerializeField] private Bullet bulletPrefab;

    public override void Update()
    {
        base.Update();

        if(isUsing)
        {
            currentLaserTime += Time.deltaTime;
            if(currentLaserTime >= laserTime)
            {
                isUsing = false;
                currentLaserTime = 0f;
                isOnCooldown = true;
            }
            else
            {
                StartCoroutine(SpawnBullet());
            }
        }
    }

    public override void UseAbility()
    {
        isUsing = true;
    }

    IEnumerator SpawnBullet()
    {
        Bullet bulletGO = Instantiate(bulletPrefab, Base.instance.transform.position, Quaternion.identity);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newDir = new Vector2(mousePos.x-Base.instance.transform.position.x, mousePos.y-Base.instance.transform.position.y);
        bulletGO.setDirection(newDir);

        yield return new WaitForSeconds(timeBtwBullet);
    }
}

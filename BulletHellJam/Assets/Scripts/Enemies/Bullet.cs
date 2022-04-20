using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float hitboxRadius = 1f;
    public int damageAmount = 1;
    public void setDirection(Vector2 dir){
        transform.right = dir;
    }
}

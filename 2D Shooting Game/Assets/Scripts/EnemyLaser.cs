using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour
{
    public float damage = 150f;

    public float getDamage()
    {
        return damage;
    }

    public void hit()
    {
        Destroy(gameObject);
    }
}

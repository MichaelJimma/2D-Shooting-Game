using UnityEngine;
using System.Collections;

public class EnemyMeteor : MonoBehaviour
{
    public float damage = 100f;
    public float getDamage()
    {
        return damage;
    }

    public void hit()
    {
        Destroy(gameObject);
    }
}

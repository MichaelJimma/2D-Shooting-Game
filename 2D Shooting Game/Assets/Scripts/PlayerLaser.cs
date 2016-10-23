using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour
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

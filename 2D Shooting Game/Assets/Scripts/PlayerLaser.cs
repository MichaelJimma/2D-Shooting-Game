/*
 ScoreKeeper.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: Uses to destroy any object that collide with it. I used it to destroy the laser objects from keep flooding the memory
 */

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

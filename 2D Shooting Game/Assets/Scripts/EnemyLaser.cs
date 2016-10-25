/*
 EnemyLaser.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This is a utility object to control the enemy's laser amount of damage 
 */


using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour
{
    //sets the amount of damage for each hit to the enemy. for example if the damage property in EnemyBehaviour sets to 100f, 
    //we need to hit the enemy 3 times to destroy it;

    public float damage = 100f;

    public float getDamage()
    {
        //returns the amount of damage
        return damage;
    }

    public void hit()
    {
        //Destroys the laser object
        Destroy(gameObject);
    }
}

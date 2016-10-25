/*
 EnemyBehaviour.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: Controls different enemy behaviours such as score, laser speed and shooting frequency
 */

using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    private float health = 300f;
    public float laserSpeed = 2f;
    public GameObject laser;
    public float firesPerSecond = 0.9f;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;
    public AudioClip laserSound;
    public AudioClip deadSound;

    void Start()
    {
        //Create ScoreKeeper object to access Score method of the object
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        //Sets the probability enemy's laser shooting by multiplying time.delta by the given firespersecond value, (0.9) in our case
        float probability = Time.deltaTime * firesPerSecond;

        //this creates a random shooting frequency instead of a constant shooting
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerLaser laser = collider.gameObject.GetComponent<PlayerLaser>();

        if (laser)
        {
            //if the player laser hits the enemy, enemy's health will decrease by the value set in PlayerLaser object
            health -= laser.getDamage();//returns the current damage value
            laser.hit();
            if (health <= 0)
            {
                //this sound clip will be played everytime the enemy plane destroyed
                AudioSource.PlayClipAtPoint(deadSound, transform.position);

                //if enemy health is less than or equal to 0, the object will be destroyed
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);  
            }
        }
    }

    void Fire()
    {
        Vector3 laserStartPosition = transform.position + new Vector3(-1, 0, 0);
        GameObject laserBullet = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        laserBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-laserSpeed, 0);

        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }
   
}

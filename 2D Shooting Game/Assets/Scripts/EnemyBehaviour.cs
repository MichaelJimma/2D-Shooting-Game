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
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = Time.deltaTime * firesPerSecond;

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
            health -= laser.getDamage();
            laser.hit();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(deadSound, transform.position);
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

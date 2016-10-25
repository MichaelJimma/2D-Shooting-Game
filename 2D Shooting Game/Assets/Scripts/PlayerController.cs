/*
 PlayerController.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description:This controller class contrlos the overall movement of the player object,plays the laser and hit sound,
 records the player life, destroy the player after 5 hits and load the game over level scene.
 */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    float Xmax = 4.5f;
    float Xmin = -6.0f;
    float Ymax = 6.0f;
    float Ymin = -6.0f;
    public float laserSpeed = 10f;
    public float firingRate = 0.2f;
    private float health = 700f;
    public int lifeValue = 1;
    public AudioClip laserSound;
    public AudioClip deadSound;
    private LifeKeeper lifeKeeper;
    public GameObject laserBullet;

    void Start ()
    {
        //create a lifekeeper object to utilize the player's life
        lifeKeeper = GameObject.Find("Life").GetComponent<LifeKeeper>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //player fire laser when user press space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //calls the Fire() method in a timely manner(firingRate) even if the player press the space key continiously
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            //stops calling Fire() method when the player release the space key
            CancelInvoke("Fire");
        }

        //moves the player object according to the input button. We can use Arrow/WASD combinations
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        //Restrict the player to the game space in the x direction
        float Xnew = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector3(Xnew, transform.position.y, transform.position.z);

        //Restrict the player to the game space in the y direction
        float Ynew = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(transform.position.x, Ynew, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyLaser laser = collider.gameObject.GetComponent<EnemyLaser>();

        //if the player collides with an enemy laser, the dead sound plays and health decreased by 1  
        if (laser)
        {
            AudioSource.PlayClipAtPoint(deadSound, transform.position);
            health -= laser.getDamage();
            lifeKeeper.Life(lifeValue);
            laser.hit();
            if (health <= 0)
            {
                //if the health of the player is 0, the player object will be destroyed and the level will be changed to Game Over
                LevelManager levManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                levManager.LoadLevel("Win Screen");
                Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        //Instantiates the laser object everytime Fire() called and project it towards x position in laserSpeed.
        GameObject laser = Instantiate(laserBullet, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(laserSpeed, 0);

        //plays laserSound in creation of every laser object
        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }
}

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
    private float health = 300f;
    public GameObject laserBullet;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        //Moving inputs
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

        //Restrict the player to the game space
        float Xnew = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        transform.position = new Vector3(Xnew, transform.position.y, transform.position.z);

        float Ynew = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(transform.position.x, Ynew, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyLaser laser = collider.gameObject.GetComponent<EnemyLaser>();

        if (laser)
        {
            health -= laser.getDamage();
            laser.hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        GameObject laser = Instantiate(laserBullet, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(laserSpeed, 0);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class EnemyMaker : MonoBehaviour {
    public GameObject parentPrefab;
    public GameObject enemyPrefab;
    public float width = 14f;
    public float height = 12f;

    //Startup position for the 
    private bool moveRight = true;
    public float speed = 2f;
    float Ymax = 2f;
    float Ymin = -2f;

    int parentNumber = 1;
    void Start()
    {
        createEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy formation to the right or left according to the condition
        if (moveRight)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime);
        }

        //Determines the most top and bottom of the playground where the enemies can move
        float topEdgeOfFormation = transform.position.y + (0.3f * height);
        float bottomEdgeOfFormation = transform.position.y - (0.3f * width);

        if (topEdgeOfFormation < Ymax)
        {
            moveRight = true;
        }
        else if(bottomEdgeOfFormation > Ymin)
        {
            moveRight = false;
        }

        //If the player kills all the enemies, we create a new anemy formation
        if (allEnemiesDead())
        {
            createEnemies();
        }
    }

    void createEnemies()
    {
        float x = UnityEngine.Random.Range(-3, 6);
        float y = UnityEngine.Random.Range(3, -3);
        Vector2 pos = new Vector2(x, y);

        //Instantiate a new parent object everytime all the enemies are killed and increment the number of parent object by one
        for (int i = 0; i < parentNumber; i++)
        {
            GameObject parent = Instantiate(parentPrefab, pos, Quaternion.identity) as GameObject;
            parent.transform.parent = transform;
        }
        parentNumber++;

        foreach (Transform child in transform)
        {
            //Instantiate a new enemy prefab on each parent's position
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private bool allEnemiesDead()
    {
        //Check if all enemies are killed by counting child objects from the parent 
        foreach (Transform enemyPositionObject in transform)
        {
            if(enemyPositionObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    public void OnDrawGizmos()
    {
        //Useful in design to see a border around the parent object
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}

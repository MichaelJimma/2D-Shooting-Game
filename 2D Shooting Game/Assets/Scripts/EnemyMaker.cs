using UnityEngine;
using System.Collections;
using System;

public class EnemyMaker : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 14f;
    public float height = 12f;

    //Startup position for the 
    private bool moveRight = true;
    public float speed = 2f;
    float Ymax = 2f;
    float Ymin = -2f;
    void Start()
    {
        createEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime);
        }

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

        if (allEnemiesDead())
        {
            createEnemies();
        }
    }

    void createEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private bool allEnemiesDead()
    {
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
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}

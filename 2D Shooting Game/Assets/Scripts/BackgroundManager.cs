using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{

    //Set from Unity
    [SerializeField]
    float speed = 5f;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform = null;
    private Vector2 _currentPosition;

    //Constants
    private const float startPos = 312f;
    private const float resetPos = -6f;

    // Use this for initialization
    void Start()
    {

        _transform = gameObject.transform;
        _currentPosition = _transform.position;

        //Reset the position
        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //TODO: Your implementation of the scrolling backgriund
        _currentPosition = transform.position;
        _currentPosition -= new Vector2(speed * Time.deltaTime, 0);
        _transform.position = _currentPosition;


        if (gameObject.transform.position.x < resetPos)
            Reset();
    }

    public void Reset()
    {

        //TODO: Reset backgorund
        float xpos = Random.Range(5f, 20f);
        float ypos = Random.Range(-3f, 3f);
        _currentPosition = new Vector2(6, 0);
        _transform.position = _currentPosition;
    }
}

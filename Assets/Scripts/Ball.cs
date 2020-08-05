using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    public float bounceForce;
    bool gameStarted;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                startBounce();
                gameStarted = true;
                GameManager.instance.gameStart();
            }
        }
    }

    void startBounce()
    {

        Vector2 randomDirection = new Vector2((float)Random.Range(-10000, 10000) / 10000, 1);

        if (randomDirection.x == 0)
        {
            randomDirection.x = 1;
        }

        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //checks for collsion

        if (other.gameObject.tag == "Fall")
        {
            //checks if the colliding body has the tag of FallCheck
            GameManager.instance.restart();
        }

        else if (other.gameObject.tag == "Paddle")
        {
            GameManager.instance.scoreUp();
        }
    }
}

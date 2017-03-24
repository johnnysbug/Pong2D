using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{
    Rigidbody2D rigidBody;

    public float speed = 15f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Invoke("RandomizeStart", 3.0f);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var xVelocity = rigidBody.velocity.x;
            var yVelocity = (transform.position.y + collision.transform.position.y) / collision.collider.bounds.size.y;
            var direction = new Vector2(xVelocity, yVelocity).normalized;

            rigidBody.velocity = direction * speed;
        }
    }

    void RandomizeStart()
    {
        var randomX = Random.Range(0, 2) == 0 ? -1 : 1;
        var randomY = Random.Range(0, 2) == 0 ? -1 : 1;

		rigidBody.position = Vector2.zero;
        rigidBody.velocity = new Vector2(randomX, randomY) * speed;
    }

    void Reset()
    {
        rigidBody.velocity = Vector2.zero;
    }

    void Restart()
    {
        Reset();
        Invoke("RandomizeStart", 1.5f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehavior : MonoBehaviour
{

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < -10)
        {
            Destroy(gameObject);
        }

        // Access script of the player (through his tag) and get the script component to access the variable Alive
        bool isAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>().Alive;
        if (!isAlive)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

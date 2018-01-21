using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour {

    Rigidbody2D rb;
    CubeSchildpadController player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>();
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
        if (!player.Alive)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

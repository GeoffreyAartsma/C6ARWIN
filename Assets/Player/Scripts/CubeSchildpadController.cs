﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSchildpadController : MonoBehaviour {

    Rigidbody2D rb;

    [SerializeField]
	Text countText, gameOverText;
    
    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float multiplyer;

	int count;
    
    public bool Alive { get; set; }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX |
                         RigidbodyConstraints2D.FreezeRotation;
        maxSpeed = 30f;
        multiplyer = 8f;
		count = 0;
		SetCountText ();
		setGameOverText (false);
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    // FixedUpdate is called once per time step
    void FixedUpdate () {
        if (Alive)
        {
            float moveVertical = Input.GetAxis("Vertical") * multiplyer;
            Vector2 movement = new Vector2(0.0f, moveVertical);

            rb.AddForce(movement);

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

            if (rb.position.y < -5f)
            {
                rb.MovePosition(new Vector2(rb.position.x, -5f));
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * 0.3f);
            }
            else if (rb.position.y > 5f)
            {
                rb.MovePosition(new Vector2(rb.position.x, 5f));
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
        }
        
        // Handles start
        else if (Input.GetKey(KeyCode.Return))
        {
			gameOverText.enabled = false;
            rb.position = new Vector2(rb.position.x, 0);
            count = 0;
            SetCountText();

            foreach (GameObject fish in GameObject.FindGameObjectsWithTag("PickUp")) {
                Destroy(fish);
            }

			foreach (GameObject Net in GameObject.FindGameObjectsWithTag("Net")) {
				Destroy (Net);
			}


            Alive = true;
        }
	}

    // Handles collisions
	void OnTriggerEnter2D(Collider2D other) { 	
		if (other.gameObject.CompareTag("PickUp"))
		{
            Destroy (other.gameObject);
			count = count + 1;
			SetCountText ();
		}

        if (other.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero;
            Alive = false;
			setGameOverText (true);
            gameOverText.enabled = true;
        }

        if (other.gameObject.CompareTag("Net"))
        {
            rb.velocity = Vector2.zero;
            Alive = false;
			setGameOverText (true);
            gameOverText.enabled = true;
        }
    }

    // Update UI
	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
	}

	void setGameOverText(bool game_over) {
		if (game_over) {
			gameOverText.text = "Game Over";
		} else {
			gameOverText.text = "Start";
		}
	}
}
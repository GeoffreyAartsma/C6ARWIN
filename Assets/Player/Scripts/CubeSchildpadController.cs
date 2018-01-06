using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSchildpadController : MonoBehaviour {
    Rigidbody2D rb;

	public Text countText;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float multiplyer;

	private int count;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX |
                         RigidbodyConstraints2D.FreezeRotation;
        maxSpeed = 30f;
        multiplyer = 8f;
		count = 0;
		SetCountText ();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
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


	void OnTriggerEnter2D(Collider2D other) { 	
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}

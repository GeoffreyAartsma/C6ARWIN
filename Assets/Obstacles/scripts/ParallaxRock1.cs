using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRock1 : MonoBehaviour {

    [SerializeField]
    float speed;
    Renderer rend;
    CubeSchildpadController player;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>();
        rend = GetComponent<Renderer>();
    }


    void FixedUpdate () {
        
        // Access script of the player (through his tag) and get the script component to access the variable 
        if (player.Alive)
        {
            transform.position -= new Vector3(speed, 0);
            float right = rend.bounds.extents.x;
            float leftScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x;

            if (transform.position.x + right < leftScreen)
            {
                transform.position = new Vector3(leftScreen + right * 3, transform.position.y, transform.position.z);
            }
        }

           
      
        
	}
}

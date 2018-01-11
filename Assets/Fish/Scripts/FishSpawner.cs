using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D prefab;
    Rigidbody2D clone;

    int wave = 1;

    // TO DO: Add Wave System


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Access script of the player (through his tag) and get the script component to access the variable Alive
        bool isAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>().Alive;

        if (GameObject.FindGameObjectWithTag("PickUp") == null && isAlive) 
        {
            for (int i = 0; i < Mathf.Clamp(wave, 0, 5); i++)
            {
                clone = Instantiate(prefab, new Vector2(transform.position.x, Random.Range(-5.0f, 5.0f)), transform.rotation) as Rigidbody2D;
                clone.velocity = new Vector2(-10f, 0f);
            }

            wave++;
        } else if (!isAlive)
        {
            wave = 1;
        }
    }
}

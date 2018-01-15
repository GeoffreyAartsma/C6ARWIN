using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawner : MonoBehaviour
{

    [SerializeField]
    public Rigidbody2D Net;
    Rigidbody2D clone;

    int wave = 1;
    float baseline = -6f;

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // Access script of the player (through his tag) and get the script component to access the variable Alive
        bool isAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>().Alive;

        if (GameObject.FindGameObjectWithTag("Net") == null && isAlive)
        { 
            // Select random prefab out of the prefabslist and instanciate random fish 
            clone = Instantiate(Net, new Vector2(transform.position.x, 3f), transform.rotation) as Rigidbody2D;

            // Baseline variables around different speed values
            float vx = baseline + Random.Range(-1f, 1f);
            clone.velocity = new Vector2(vx, 0f);


            // baseline = baseline - 0.1f
            baseline -= 0.1f;
            wave++;
        }
        else if (!isAlive)
        {
            wave = 1;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D fish1, fish2, fish3, fish4;
    Rigidbody2D clone;

    List<Rigidbody2D> prefabList = new List<Rigidbody2D>();

    [SerializeField]
    int chanceOfSpawning;

    float baseline = -6f;
    int fishSpawnesLeft;
    int wave = 1;


    // Use this for initialization
    void Start()
    {
        prefabList.Add(fish1);
        prefabList.Add(fish2);
        prefabList.Add(fish3);
        prefabList.Add(fish4);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Access script of the player (through his tag) and get the script component to access the variable Alive
        bool isAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeSchildpadController>().Alive;

        if (fishSpawnesLeft > 0 && isAlive)
        {
            if (Random.Range(0, chanceOfSpawning) == 0)
            {
                // Select random prefab out of the prefabslist and instanciate random fish 
                int prefabIndex = Random.Range(0, 4);
                clone = Instantiate(prefabList[prefabIndex], new Vector2(transform.position.x, Random.Range(-5.0f, 5.0f)), transform.rotation) as Rigidbody2D;

                // Baseline variables around different speed values
                float vx = baseline + Random.Range(-1f, 1f);
                clone.velocity = new Vector2(vx, 0f);
                
                fishSpawnesLeft--;
            }            
        }
        else if (fishSpawnesLeft == 0 && GameObject.FindGameObjectWithTag("PickUp") == null && isAlive)
        {
            // baseline = baseline - 0.1f
            baseline -= 0.1f;
            wave++;
            fishSpawnesLeft = wave; 
        }
        else if (!isAlive)
        {
            wave = 1;
            fishSpawnesLeft = 1;
        }
    }
}

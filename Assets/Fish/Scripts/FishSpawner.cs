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
        if (GameObject.FindGameObjectsWithTag("PickUp") == null) 
        {
            for (int i = 0; i < wave; i++)
            {
                clone = Instantiate(prefab, new Vector2(transform.position.x, Random.Range(-5.0f, 5.0f)), transform.rotation) as Rigidbody2D;
                clone.velocity = new Vector2(-10f, 0f);
            }
            wave++;
        }
        else
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("PickUp"));
        }                

    }
}

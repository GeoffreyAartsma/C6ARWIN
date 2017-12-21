using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D prefab;

    // Use this for initialization
    void Start()
    {
        Rigidbody2D clone;
        clone = Instantiate(prefab, new Vector2(transform.position.x, Random.Range(-5.0f, 5.0f)), transform.rotation) as Rigidbody2D;
        clone.velocity = new Vector2(-10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

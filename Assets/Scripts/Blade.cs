using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float damage, timeBetweenSwings;
    GameObject[] walls;
    // Start is called before the first frame update
    void Awake()
    {
        damage = Random.Range(3.0f, 10.0f);
        timeBetweenSwings = Random.Range(0.1f, 0.9f);
        
    }

    private void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Walls");
    }
    // Update is called once per frame
    void Update()
    {
        //might improve later --> stops weapon from colliding with wall
       Physics2D.IgnoreLayerCollision(0, 9);
    }
}

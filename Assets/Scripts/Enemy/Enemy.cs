using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float moveSpeed;
    public float health;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 2;
        health = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void ChangeHealth(float Value)
    {

        health += Value;

        if (health <=0)
        {

            //Die();

        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float moveSpeed;
    public float health;

    public float maxHealth = 50f;

    public EnemyHealthBar healthBar;

    public Transform healthBarPostitionSet;

    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 2;
        health = maxHealth;

        uimanager = FindObjectOfType<UIManager>();
        


        
        
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.targetPosition = healthBarPostitionSet;

        if (Input.GetKeyUp(("e")))
        {


            ChangeHealth(-10f);
        }
    }




    void ChangeHealth(float Value)
    {

        health += Value;
        healthBar.ChangeHealth(health/maxHealth);

        if (health <=0)
        {

            //Die();

        }


    }

}

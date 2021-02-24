using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject weapon;
    public Transform weaponHoldPoint;

    public Rigidbody2D rigidbody;
    public float moveSpeed;
    public float health;
    bool dying = false;
    float shrinkScale = 0;

    public float maxHealth = 50f;

    public EnemyHealthBar healthBar;

    public Transform healthBarPostitionTarget;

    UIManager uimanager;
    WeaponManager wp;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 2;
        health = maxHealth;

        uimanager = FindObjectOfType<UIManager>();

        wp = FindObjectOfType<WeaponManager>();

        healthBar = uimanager.GiveEnemyHealthBar();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.moveHealthBar(healthBarPostitionTarget);

        if (Input.GetKeyUp(("e")))
        {


            ChangeHealth(-10f);
        }

        //weapon.transform.position = weaponHoldPoint.transform.position;


        if (dying) { dyingEffect(); }
    }




    void ChangeHealth(float Value)
    {

        health += Value;
        healthBar.ChangeHealth(health/maxHealth);

        if (health <=0)
        {

            Kill();

        }


    }

    public void Kill()
    { 
        dying = true;
        dyingEffect();


    }

    void dyingEffect()
    {
        gameObject.transform.localScale = new Vector3(1, transform.localScale.y - shrinkScale, 1);

        shrinkScale += (0.05f * Time.deltaTime);
        Mathf.Clamp(shrinkScale, 0.0f, 0.5f);

        if(transform.localScale.y < 0.1)
        {
            Dead();

        }
    }


    void Dead()
    {
        Destroy(healthBar.gameObject);
        Destroy(this.gameObject);


    }
}

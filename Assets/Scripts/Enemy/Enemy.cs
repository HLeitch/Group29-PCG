using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Weapon weapon;
    public Transform weaponHoldPoint;

    public Rigidbody2D rigidbody;
    public float moveSpeed;
    public float health;
    bool dying = false;
    float shrinkScale = 0;
    Vector2 distanceToPlayer;
    public bool usingWeapon = false;

    public float maxHealth = 50f;

    public EnemyHealthBar healthBar;

    public Transform healthBarPostitionTarget;

    UIManager uimanager;
    WeaponManager wp;
    public RoomEnemiesManager rem;
    GameObject player;
    Animator animator;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
        health = maxHealth;

        uimanager = FindObjectOfType<UIManager>();

        wp = FindObjectOfType<WeaponManager>();

        healthBar = uimanager.GiveEnemyHealthBar();

        player = FindObjectOfType<PlayerMovement>().gameObject;

        animator = GetComponent<Animator>();

        //weapon = rem.GiveWeapon();
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


        MoveEnemy();

        

    }

    private void OnCollisionEnter(Collision collision)
    {

       
        if ((collision.gameObject.tag == "Blade"))
        {

            ChangeHealth(-10);
        }
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
        animator.enabled = false;

        gameObject.transform.localScale = new Vector3(1, transform.localScale.y - shrinkScale, 1);

        shrinkScale += (0.05f * Time.deltaTime);
        Mathf.Clamp(shrinkScale, 0.0f, 0.5f);

        if(transform.localScale.y < 0.1)
        {
            Dead();

        }
    }

    void MoveEnemy()
    {
        if (!usingWeapon)
        {
            Vector2 targetDestination = player.transform.position;

            Vector2 currentLocation = gameObject.transform.position;

            Vector2 distanceToTarget = targetDestination - currentLocation;

            Vector2 directionToTarget = distanceToTarget.normalized;
           animator.SetFloat("MoveX", directionToTarget.x);

            Vector2 movement = (directionToTarget * moveSpeed * Time.deltaTime);

            this.gameObject.transform.position += new Vector3(movement.x, movement.y, 0f);
        }
    }

    public void UseWeapon()
    {
        if (!usingWeapon)
        {


            Debug.Log("ENEMY SWINGS WEAPON");
            usingWeapon = true;
        }



    }

    void Dead()
    {
        Destroy(healthBar.gameObject);
        Destroy(this.gameObject);


    }
}

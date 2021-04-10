using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Weapon weapon;
    public Transform weaponHoldPoint;

    [SerializeField]
    public Rigidbody2D rb;
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
    WeaponManager weaponManager;
    public RoomEnemiesManager rem;
    GameObject player;
    Animator animator;
    [SerializeField]
    Animator weaponAnimator;

    public float enemyKnockback;
    public float enemyKnockbackLength;
    public float enemyKnockBackCount;
    public bool knockFromRight;

    void Awake()
    {
        
        
        health = maxHealth;

        uimanager = FindObjectOfType<UIManager>();

        weaponManager = FindObjectOfType<WeaponManager>();

        healthBar = uimanager.GiveEnemyHealthBar();

        player = FindObjectOfType<PlayerMovement>().gameObject;

        animator = GetComponent<Animator>();



        weaponManager.GiveWeapon(weapon);

        enemyKnockbackLength = 0.2f;
        enemyKnockback = 2;

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.moveHealthBar(healthBarPostitionTarget);

        if (Input.GetKeyUp(("'")))
        {


            ChangeHealth(-10f);
        }

        //weapon.transform.position = weaponHoldPoint.transform.position;


        if (dying) { dyingEffect(); }


        

        

    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }




    public void ChangeHealth(float Value)
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
        if (enemyKnockBackCount <= 0)
        {
            if (!usingWeapon)
            {
                Vector2 targetDestination = player.transform.position;

                Vector2 currentLocation = rb.position;

                Vector2 distanceToTarget = targetDestination - currentLocation;

                Vector2 directionToTarget = distanceToTarget.normalized;
                animator.SetFloat("MoveX", directionToTarget.x);

                Vector2 movement = (directionToTarget * moveSpeed);

                Vector2 newPosition = rb.position + movement;

                rb.velocity = movement;
            }
        }
        else
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(enemyKnockback, rb.velocity.y);
            }
            if (!knockFromRight)
            {
                rb.velocity = new Vector2(-enemyKnockback, rb.velocity.y);
            }
            enemyKnockBackCount -= Time.deltaTime;
        }
    }

    public void UseWeapon()
    {
        if (!usingWeapon)
        {
            weaponAnimator.Play("SwingSword");

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

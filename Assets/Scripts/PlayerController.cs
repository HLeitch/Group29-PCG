using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float storedX, storedY;
    private bool facingLeft = true;
    private Animator myAnimator;
    public float timeBetweenAttack = 0.6f;
    public float startTimeBetweenAttack;
    private bool swinging = false;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBetweenAttack = timeBetweenAttack;
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.FindObjectOfType<Weapon>();
        startTimeBetweenAttack = weapon.timeBetweenAttacks;
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        movement = movement.normalized * Time.deltaTime;
        transform.position += movement * moveSpeed;

        SetRunningAnimation();

        StartCoroutine(SwingWeapon());

        if (transform.position.x > storedX && facingLeft == true && swinging == false)
        {
            facingLeft = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < storedX && facingLeft == false && swinging == false)
        {
            facingLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        storedX = transform.position.x;
        storedY = transform.position.y;
    }

    void SetRunningAnimation()
    {
        if (transform.position.x > storedX || transform.position.y > storedY)
            myAnimator.SetBool("Running", true);
        else if (transform.position.x < storedX || transform.position.y < storedY)
            myAnimator.SetBool("Running", true);
        else
            myAnimator.SetBool("Running", false);
    }

    IEnumerator SwingWeapon()
    {
        myAnimator.SetInteger("SwingSpeed", weapon.speed);
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                myAnimator.SetFloat("Speed", weapon.speed);
                myAnimator.SetBool("Swinging", true);
                swinging = true;
                if (weapon.speed == 0)
                    yield return new WaitForSeconds(0.5f);
                else if (weapon.speed == 1.0)
                    yield return new WaitForSeconds(0.666666f);
                else if (weapon.speed == 2.0)
                    yield return new WaitForSeconds(0.3333333f);
                timeBetweenAttack = startTimeBetweenAttack;
                swinging = false;
                myAnimator.SetBool("Swinging", false);
            }
        }
        else
            timeBetweenAttack -= Time.deltaTime;
    }
}

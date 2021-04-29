using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float drag;
    //[HideInInspector]
    public float weapon_weight;
    Rigidbody2D rb;
    Vector2 movement;
    //PlayerCombat combat;
    public float playerKnockback;
    public float playerKnockbackLength;
    public float playerKnockBackCount;
    public bool knockFromRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //combat = GetComponent<PlayerCombat>();
    }

    void FixedUpdate()
    {
        if (playerKnockBackCount <= 0)
        {
            // Assign axis data to vector
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Restrict the weapon weight to be 0-1
            weapon_weight = Mathf.Clamp(weapon_weight, 0, 1); // This will be removed once the player can have a weapon

            // Increase the velocity vector
            rb.velocity += movement.normalized * (speed * (1 - weapon_weight)) * Time.deltaTime;

            // Apply the drag
            rb.velocity *= drag;
        }
        else
        {
            if(knockFromRight)
            {
                rb.velocity = new Vector2(playerKnockback, rb.velocity.y);
            }
            if(!knockFromRight)
            {
                rb.velocity = new Vector2(-playerKnockback, rb.velocity.y);
            }
            playerKnockBackCount -= Time.deltaTime;
        }
    }
}

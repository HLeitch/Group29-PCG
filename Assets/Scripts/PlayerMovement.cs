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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //combat = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        // Assign axis data to vector
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Restrict the weapon weight to be 0-1
        weapon_weight = Mathf.Clamp(weapon_weight, 0, 1); // This will be removed once the player can have a weapon

        // Increase the velocity vector
        rb.velocity += movement.normalized * (speed * (1-weapon_weight)) * Time.deltaTime;

        // Apply the drag
        rb.velocity *= drag;
    }
}

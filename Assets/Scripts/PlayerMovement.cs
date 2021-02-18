using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float drag;
    public float weapon_weight;
    Rigidbody2D rb;
    Vector2 movement;
    SpriteRenderer spr;
    ParticleSystem parts;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        parts = GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        anim.StopPlayback();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0) spr.flipX = true;
        else if (movement.x > 0) spr.flipX = false;

        weapon_weight = Mathf.Clamp(weapon_weight, 0, 1);
        rb.velocity += movement.normalized * (speed * (1-weapon_weight)) * Time.deltaTime;

        if (rb.velocity.magnitude < 1)
        {
            rb.velocity = Vector2.zero;
            if (parts.isPlaying) parts.Stop();
        }
        else
        {
            if (!parts.isPlaying) parts.Play();
        }
        anim.SetFloat("Velocity", rb.velocity.magnitude);

        rb.velocity *= drag;
    }
}

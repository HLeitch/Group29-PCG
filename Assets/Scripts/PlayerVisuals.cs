using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spr;
    ParticleSystem parts;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        parts = GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        anim.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0) spr.flipX = true;
        else if (rb.velocity.x > 0) spr.flipX = false;

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
    }
}

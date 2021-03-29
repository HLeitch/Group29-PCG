using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spr;
    ParticleSystem parts;
    Animator anim;
    public GameObject pivot;
    private PlayerCombat pc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        parts = GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
        anim.StopPlayback();
        pc = GetComponent<PlayerCombat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.x < 0) spr.flipX = true;
        //else if (rb.velocity.x > 0) spr.flipX = false;

        if (rb.velocity.x < 0 && pc.swinging != true) transform.localScale = new Vector3(-1, 1, 1);
        else if (rb.velocity.x > 0 && pc.swinging != true) transform.localScale = new Vector3(1, 1, 1);

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

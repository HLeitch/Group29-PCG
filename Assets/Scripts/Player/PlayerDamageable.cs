﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Add to player damage hitbox.
/// </summary>
public class PlayerDamageable : MonoBehaviour,IDamageable
{
    float invunerableTime = 0.0f;
    float maxInvunerableTime = 0.2f;
    bool invunerable = false;
    PlayerCombat myPlayer;
    [SerializeField]
    SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponentInParent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invunerable)
        {
            invunerableTime -= Time.deltaTime;
            if(invunerableTime < 0.0f)
            {
                invunerable = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {

        if (!invunerable)
        {
            if (collision.gameObject.tag == "Blade")
            {
                if (collision.GetComponentInParent<Weapon>().gameObject.layer == 9)
                {
                    ChangeHealth(collision.GetComponent<Blade>().damage);
                    invunerable = true;
                    invunerableTime = maxInvunerableTime;
                    StartCoroutine(Flash());
                    

                    Debug.Log("Starting Knockback");
                    var playerMov = FindObjectOfType<PlayerMovement>();
                    playerMov.playerKnockback = collision.GetComponentInParent<Weapon>().knockback;
                    if (collision.GetComponentInParent<Enemy>().transform.position.x < transform.position.x)
                        playerMov.knockFromRight = true;
                    else
                        playerMov.knockFromRight = false;
                    playerMov.playerKnockBackCount = playerMov.playerKnockbackLength;
                }

            }
            if (collision.CompareTag("Projectile"))
            {
                ChangeHealth(collision.gameObject.GetComponent<Projectile>().damage);
                invunerable = true;
                invunerableTime = maxInvunerableTime;
                StartCoroutine(Flash());

                Destroy(collision.gameObject);
            }
        }

    }

    public void ChangeHealth(float amount)
    {

        myPlayer.TakeDamage(Mathf.RoundToInt(amount));

    }


    IEnumerator Flash()
    {
        while (invunerable)
        {
            playerSprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = Color.white;
        }
    }

}

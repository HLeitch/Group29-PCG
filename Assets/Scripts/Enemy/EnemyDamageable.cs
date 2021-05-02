using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour,IDamageable
{
    [SerializeField]
    Enemy myEnemy;
    [SerializeField]
    SpriteRenderer enemySprite;
    bool invunerable = false;
    float maxInvunerableTime = 0.2f;
    float invunerableTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        myEnemy = gameObject.GetComponentInParent<Enemy>();
    }
    void Update()
    {

        if(invunerable)
        {
            invunerableTime -= Time.deltaTime;
            if(invunerableTime < 0.0f)
            {
                invunerable = false;
                invunerableTime = 0.2f;
            }

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (!invunerable)
        {
            if ((collision.gameObject.tag == "Blade") && (collision.gameObject.layer != 9))
            {
                SoundManager.playSound("hit_sound", 1, collision.GetComponent<Blade>().damage / 10);

                ChangeHealth(-collision.gameObject.GetComponent<Blade>().damage);

                Debug.Log("HEALTH TAKEN BY: " + collision.gameObject.name);
                invunerable = true;
                StartCoroutine(Flash());


                Debug.Log("Starting Knockback");
                var enemyMov = gameObject.GetComponentInParent<Enemy>();
                enemyMov.enemyKnockback = collision.GetComponentInParent<Weapon>().knockback;
                if (collision.GetComponentInParent<PlayerMovement>().transform.position.x < transform.position.x)
                    enemyMov.knockFromRight = true;
                else
                    enemyMov.knockFromRight = false;
                enemyMov.enemyKnockBackCount = enemyMov.enemyKnockbackLength;

            }
        }
    }

    public void ChangeHealth(float amount)
    {

        myEnemy.ChangeHealth(amount);

    }

    IEnumerator Flash()
    {
        while (invunerable)
        {
            enemySprite.color = Color.black;
            yield return new WaitForSeconds(0.2f);
         enemySprite.color = Color.white;
        }
    }
}

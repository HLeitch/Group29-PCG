using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRange : MonoBehaviour
{

    Enemy parentEnemy;
    BoxCollider2D range;
    bool reacting = false;
    public float reactionTime = 0.3f;
    float reactionTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        parentEnemy = GetComponentInParent<Enemy>();
        reactionTimer = reactionTime;
    }

    private void Update()
    {
        if(reacting)
        {
            reactionTimer -= Time.deltaTime;
            if (reactionTimer < 0)  
            {
                reacting = false;
                reactionTimer = reactionTime;
            parentEnemy.UseWeapon();
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided with");

            if(!reacting)
            {
                reacting = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}

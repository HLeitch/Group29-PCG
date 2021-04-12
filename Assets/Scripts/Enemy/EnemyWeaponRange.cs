using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRange : MonoBehaviour
{

    Enemy parentEnemy;
    BoxCollider2D range;
    
    public float reactionTime = 0.1f;
    float reactionTimer = 0.0f;
        bool reacting = false;

    // Start is called before the first frame update
    void Start()
    {
        parentEnemy = GetComponentInParent<Enemy>();   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !reacting)
        {
            Debug.Log("Player Collided with");
            parentEnemy.usingWeapon = false;
         
            reacting = true;
            reactionTimer = reactionTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void Update()
    {
        if (reacting)
        {
            reactionTimer -= Time.deltaTime;

            if (reactionTimer < 0)
                {
                parentEnemy.UseWeapon();
                reacting = false;
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRange : MonoBehaviour
{

    Enemy parentEnemy;
    BoxCollider2D range;


    // Start is called before the first frame update
    void Start()
    {
        parentEnemy = GetComponentInParent<Enemy>();   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided with");

            parentEnemy.UseWeapon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentEnemy.usingWeapon = false;
    }
}

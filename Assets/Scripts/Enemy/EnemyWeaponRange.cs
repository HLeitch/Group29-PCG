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
        parentEnemy = FindObjectOfType<Enemy>();   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        parentEnemy.UseWeapon();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentEnemy.usingWeapon = false;
    }
}

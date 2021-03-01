using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    [SerializeField]
    Enemy myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        myEnemy = gameObject.GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {


        if ((collision.gameObject.tag == "Blade"))
        {

            myEnemy.ChangeHealth(-10);
        }
    }
}

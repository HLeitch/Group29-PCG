using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float damage, timeBetweenSwings, bladeValue;

    public Collider2D myCollider;
    Weapon thisWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        //damage = Random.Range(3.0f, 10.0f);
        //timeBetweenSwings = Random.Range(0.1f, 0.9f);
        myCollider = GetComponent<Collider2D>();
        thisWeapon = GetComponent<Weapon>();
        myCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        myCollider.enabled = false;
    }

}

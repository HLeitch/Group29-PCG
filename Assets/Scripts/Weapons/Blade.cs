﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float damage, timeBetweenSwings, bladeValue;
    public Collider2D myCollider;
    Weapon parent;
    // Start is called before the first frame update
    void Awake()
    {

        parent = GetComponentInParent<Weapon>();
        //damage = Random.Range(3.0f, 10.0f);
        //timeBetweenSwings = Random.Range(0.1f, 0.9f);
        myCollider = GetComponent<Collider2D>();
        myCollider.enabled = false;

        parent.bladeCollider = myCollider;

        gameObject.layer = parent.gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

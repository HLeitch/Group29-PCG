﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage, knockback, timeBetweenAttacks;
    public int speed;
    public string weaponName;
    Hilt hilt;
    Blade blade;
    Modifier modifier;
    Effect effect;

    public void GetStats()
    {
        knockback = hilt.knockback;
        damage = blade.damage;
        knockback = hilt.knockback;
        speed = hilt.speed;
        timeBetweenAttacks = blade.timeBetweenSwings;
    }

    public void GetName()
    {
        weaponName = modifier.gameObject.name + " " + blade.gameObject.name + " " + this.tag + " of " + effect.gameObject.name;
        name = weaponName;
    }

    public void SetParts(GameObject h, GameObject b, GameObject e, GameObject m)
    {
        hilt = h.GetComponent<Hilt>();
        blade = b.GetComponent<Blade>();
        modifier = m.GetComponent<Modifier>();
        effect = e.GetComponent<Effect>();
        
        GetStats();
        GetName();
    }
}
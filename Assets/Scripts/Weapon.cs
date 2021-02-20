using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage, speed, knockback;
    public string weaponName;
    Hilt hilt;
    Blade blade;
    Modifier modifier;
    Effect effect;

    public void GetStats()
    {
        damage = hilt.damage + blade.damage;
        knockback = hilt.knockback + blade.knockback;
        speed = hilt.speed + blade.speed;
    }

    public void GetName()
    {
        weaponName = modifier.gameObject.name + " " + hilt.gameObject.name + " " + blade.gameObject.name + " of " + effect.gameObject.name;
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
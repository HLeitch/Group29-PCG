using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage, speed, knockback;
    public string weaponName;
    Hilt hilt;
    Blade blade;

    public void GetStats()
    {
        damage = hilt.damage + blade.damage;
        knockback = hilt.knockback + blade.knockback;
        speed = hilt.speed + blade.speed;
    }

    public void GetName()
    {
        weaponName = hilt.gameObject.name.Substring(4,3) + blade.gameObject.name.Substring(5,4);
        name = weaponName;
    }

    public void SetParts(GameObject h, GameObject b)
    {
        hilt = h.GetComponent<Hilt>();
        blade = b.GetComponent<Blade>();

        GetStats();
        GetName();
    }
}
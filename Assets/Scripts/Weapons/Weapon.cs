using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage, knockback, timeBetweenAttacks, speed, weaponValue;
    public string weaponName;
    Hilt hilt;
    Blade blade;
    Modifier modifier;
    Effect effect;

    public Collider2D bladeCollider;


    private void Awake()
    {
        
    }

    public void GetStats()
    {
        knockback = hilt.knockback;
        damage = blade.damage;
        knockback = hilt.knockback;
        speed = hilt.speed;
        timeBetweenAttacks = blade.timeBetweenSwings;
        weaponValue = (hilt.hiltValue + blade.bladeValue) / 2;
        

    }

    public string GetName()
    {
        int pretendValue = (int) (weaponValue * 1000) + (Random.Range(0, 99));

        weaponName = /*modifier.gameObject.name + " " + */blade.gameObject.name + " " + this.tag/* + " of " + effect.gameObject.name*/ + "\n Fearsome Rating: " + pretendValue + "\n Damage: " + damage*100 + "\n Speed " + speed*100; ;
        name = weaponName;
        return weaponName;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.playSound("potion_sound");

            PotionEffects effects = collision.gameObject.GetComponent<PotionEffects>();
            if (name.Contains("Health")) effects.health(1000);
            if (name.Contains("Damage")) effects.damageBoost(10);
            if (name.Contains("Speed")) effects.speed(50);
            if (name.Contains("Attack")) effects.attackSpeed(10);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    private PlayerCombat combat;
    private PlayerMovement movement;

    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private GameObject particles_prefab;

    [SerializeField]
    private float effect_time;

    private void Start()
    {
        combat = GetComponent<PlayerCombat>();
        movement = GetComponent<PlayerMovement>();
    }

    public IEnumerator healthCoroutine(int amount)
    {
        ParticleSystem parts = particles(Color.red);
        combat.Heal(amount);
        yield return new WaitForSeconds(3);
        Destroy(parts.gameObject);
    }

    private IEnumerator speedCoroutine(float amount)
    {
        ParticleSystem parts = particles(Color.green);
        movement.speed += amount;
        yield return new WaitForSeconds(effect_time);
        movement.speed -= amount;
        Destroy(parts.gameObject);
    }

    private IEnumerator damageCoroutine(float amount)
    {
        ParticleSystem parts = particles(Color.blue);
        weapon.damage += amount;
        yield return new WaitForSeconds(effect_time);
        weapon.damage -= amount;
        Destroy(parts.gameObject);
    }

    private IEnumerator attackSpeedCoroutine(int amount)
    {
        ParticleSystem parts = particles(Color.yellow);
        weapon.speed -= amount;
        yield return new WaitForSeconds(effect_time);
        weapon.speed -= amount;
        Destroy(parts.gameObject);
    }

    public void health(int amount)
    {
        StartCoroutine(healthCoroutine(amount));
    }

    public void speed(float amount)
    {
        StartCoroutine(speedCoroutine(amount));
    }

    public void damageBoost(float amount)
    {
        StartCoroutine(damageCoroutine(amount));
    }

    public void attackSpeed(int amount)
    {
        StartCoroutine(attackSpeedCoroutine(amount));
    }

    private ParticleSystem particles(Color color)
    {
        GameObject particleGameObject = Instantiate(particles_prefab, transform.position, transform.rotation);
        particleGameObject.transform.parent = gameObject.transform;
        ParticleSystem particles = particleGameObject.GetComponent<ParticleSystem>();

        ParticleSystem newParticles = particles;
        ParticleSystem.MainModule main = newParticles.main;
        main.startColor = color;
        particles = newParticles;

        return particles;
    }
}

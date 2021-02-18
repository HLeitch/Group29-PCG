using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int max_hp;
    int hp;
    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        // Attack code is handled by the weapon (i think)
    }

    public void GetNewWeapon()
    {
        // TODO: Use 'WeaponManager' to generate a new weapon and add it as a child to the player, and reference it with the 'weapon' variable
        Physics2D.IgnoreCollision(transform.Find("HitCollider").GetComponent<Collider2D>(), weapon.GetComponent<Collider2D>()); // Stop the player colliding with their own weapon
    }

    public void TakeDamage(int value)
    {
        hp -= value;
        if (hp < 0)
        {
            // TODO: Kill the player
        }
    }

    public void Heal(int value)
    {
        hp = Mathf.Clamp(hp+value, 0, max_hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            // TODO: TakeDamage(collision.GetComponent<SCRIPTNAME>().damage); // Replace SCRIPTNAME with name of projectile script
            // TODO: Emit particle effect?
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Weapon"))
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int max_hp;
    int hp;
    GameObject weapon;
    public WeaponManager wm;
    private float timeBetweenAttack;
    public bool swinging = false;
    public float startTimeBetweenAttack;
    private Animator weaponAnimator;
    private UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
        startTimeBetweenAttack = timeBetweenAttack;
        weaponAnimator = transform.Find("Pivot").GetComponent<Animator>();
        ui = FindObjectOfType<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SwingWeapon());
        // Attack code is handled by the weapon (i think)
        if (Input.GetKeyDown("m"))
        {
            GetNewWeapon();
        }
    }

    public void GetNewWeapon()
    {
        // TODO: Use 'WeaponManager' to generate a new weapon and add it as a child to the player, and reference it with the 'weapon' variable
        wm.ChooseWeaponType();
        Physics2D.IgnoreCollision(transform.Find("HitCollider").GetComponent<Collider2D>(), weapon.GetComponent<Collider2D>()); // Stop the player colliding with their own weapon
    }

    public void TakeDamage(int value)
    {
      hp -= value;
        Debug.Log("Health value" + hp);
        healthChange();
        if (hp < 0)
        {
            
        }
    }

    public void Heal(int value)
    {
        hp = Mathf.Clamp(hp+value, 0, max_hp);
        healthChange();
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

    IEnumerator SwingWeapon()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                weaponAnimator.SetBool("Swinging", true);
                swinging = true;
                yield return new WaitForSeconds(0.3f);
                weaponAnimator.SetBool("Swinging", false);
                yield return new WaitForSeconds(0.15f);
                swinging = false;
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
            timeBetweenAttack -= Time.deltaTime;
    }



    void healthChange()
    {
        float percentage;

        percentage = (float) hp / (float) max_hp;

        ui.changeHealthBar(percentage);
     

    }
}

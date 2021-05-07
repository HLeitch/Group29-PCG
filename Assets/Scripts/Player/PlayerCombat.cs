using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int max_hp;
    public static WeaponGeneration wg;
    int hp;
    public Weapon weapon;
    public WeaponManager wm;
    public PlayerDamageable pd;
    public float timerBetweenAttack;
    public bool swinging = false;
    public bool bigSwing = false;
    public float waitTime = 0;
    public bool smallSwing = false;

    private Animator weaponAnimator;
    private UIManager ui;

    public float startTimeBetweenAttack()
    {

        float value = weapon.timeBetweenAttacks;
        return value;
    }

    // Start is called before the first frame update
    void Start()
    {
        wg = FindObjectOfType<WeaponGeneration>();
        hp = max_hp;
        
        weaponAnimator = transform.Find("Pivot").GetComponent<Animator>();
        ui = FindObjectOfType<UIManager>();
        timerBetweenAttack = weapon.timeBetweenAttacks;
      

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SwingWeapon());
        // Attack code is handled by the weapon (i think)
        /*if (Input.GetKeyDown("m"))
        {
            GetNewWeapon();
            
        }*/

        if (timerBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                wg.UpdateSwingsTook();
            }
        }
    }

    public void GetNewWeapon()
    {
        // TODO: Use 'WeaponManager' to generate a new weapon and add it as a child to the player, and reference it with the 'weapon' variable
        wm.ChooseWeaponType();
    DisplayWeaponName();
        Physics2D.IgnoreCollision(transform.Find("HitCollider").GetComponent<Collider2D>(), weapon.GetComponent<Collider2D>()); // Stop the player colliding with their own weapon
        
    }

    public void TakeDamage(int value)
    {
        SoundManager.playSound("hit_sound", 1, Random.Range(0.75f, 1.25f));
        hp = hp - value;
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(collision.gameObject.GetComponent<Projectile>().damage); // Replace SCRIPTNAME with name of projectile script
            // TODO: Emit particle effect?
            Debug.Log("HIT");
            Destroy(collision.gameObject);
        }
    }

    IEnumerator SwingWeapon()
    {
        if (timerBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && bigSwing == false)
            {
                smallSwing = true;
                Debug.Log("Swinging weapon");
                wg.UpdateSwingsTook();
                timerBetweenAttack = startTimeBetweenAttack();
                weaponAnimator.SetBool("Swinging", true);
                weaponAnimator.SetBool("SmallSwing", true);

                weaponAnimator.speed = weapon.speed;
                waitTime = 0.3f / weapon.speed;

                swinging = true;
                weapon.bladeCollider.enabled = true;
                yield return new WaitForSeconds(waitTime);
                weaponAnimator.SetBool("Swinging", false);
                weaponAnimator.SetBool("SmallSwing", false);

                yield return new WaitForSeconds(0.15f);
                swinging = false;
                smallSwing = false;
                weapon.bladeCollider.enabled = false;
            }
            else if (Input.GetKey(KeyCode.Mouse1) && smallSwing == false)
            {
                bigSwing = true;
                Debug.Log("Swinging weapon");
                wg.UpdateSwingsTook();
                timerBetweenAttack = startTimeBetweenAttack();
                weaponAnimator.SetBool("Swinging", true);
                weaponAnimator.SetBool("BigSwing", true);

                weaponAnimator.speed = weapon.speed;
                waitTime = 0.75f / weapon.speed;

                swinging = true;
                weapon.bladeCollider.enabled = true;
                yield return new WaitForSeconds(waitTime);
                weaponAnimator.SetBool("Swinging", false);
                weaponAnimator.SetBool("BigSwing", false);
                
                yield return new WaitForSeconds(0.15f);
                swinging = false;
                bigSwing = false;
                weapon.bladeCollider.enabled = false;
            }
        }
        else if (swinging == false)
            timerBetweenAttack -= Time.deltaTime;
    }



    void healthChange()
    {
        float percentage;

        percentage = (float) hp / (float) max_hp;

        ui.changeHealthBar(percentage);
     

    }

    public int getHealth()
    {
        return hp;
    }

    public void DisplayWeaponName()
    {
        ui.NewPlayerWeapon(weapon.GetName());
    }
}

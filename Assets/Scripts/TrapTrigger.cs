using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Animator anim;
    private Shooting shooting;
    public GameObject[] firePoint;
    private PlayerCombat pc;
    
    public int spikeTrapDamage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player touches spikes
        if (gameObject.tag == "Spikes" && collision.gameObject.name == "WallCollider")
        {
            //take damage
            pc.TakeDamage(spikeTrapDamage);
            anim.SetBool("playertouch", true);
        }

        //if player touches pressure plate
        if (gameObject.tag == "Plate" && collision.gameObject.name == "WallCollider")
        {
            
            foreach(GameObject obj in firePoint)
            {
                //shoot arrows
                shooting = obj.GetComponent<Shooting>();
                shooting.Shoot();
            }
            
            anim.SetBool("playertouch", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //level 2 mechanism --> if player flips switch, shoot arrows
        if (gameObject.tag == "Switch" && collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (GameObject obj in firePoint)
                {
                    shooting = obj.GetComponent<Shooting>();
                    shooting.Shoot();
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (gameObject.tag == "Spikes" && collision.gameObject.name == "WallCollider")
            anim.SetBool("playertouch", false);

        if (gameObject.tag == "Plate" && collision.gameObject.name == "WallCollider")
        {
            anim.SetBool("playertouch", false);
            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Animator anim;
    private Shooting shooting;
    public GameObject[] firePoint;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(gameObject.tag == "Spikes" && collision.tag == "Player")
            anim.SetBool("playertouch", true);

        if (gameObject.tag == "Plate" && collision.tag == "Player")
        {
            foreach(GameObject obj in firePoint)
            {
                shooting = obj.GetComponent<Shooting>();
                shooting.Shoot();
            }
            
            anim.SetBool("playertouch", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Spikes" && collision.tag == "Player")
            anim.SetBool("playertouch", false);

        if (gameObject.tag == "Plate" && collision.tag == "Player")
        {
            anim.SetBool("playertouch", false);
           
        }
        
    }
}

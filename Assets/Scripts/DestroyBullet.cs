using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 0.25f);
        Destroy(gameObject);

        
    }


}


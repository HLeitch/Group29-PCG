using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int damage;
// Start is called before the first frame update

    //Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
            Destroy(gameObject);

    }


    private void Update()
    {
        //Ignore collision on Layer 2
        //Physics2D.IgnoreLayerCollision(2,9);
    }



}


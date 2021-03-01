using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int damage;
// Start is called before the first frame update

    //Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Walls")
            Destroy(gameObject);

    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy when hits wall
       // 

    }


    private void Update()
    {
        //Ignore collision on Layer 2
        //Physics2D.IgnoreLayerCollision(2,9);
    }



}


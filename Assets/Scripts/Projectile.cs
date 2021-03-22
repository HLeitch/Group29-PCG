using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerCombat PC;
    public int damage;
    // Start is called before the first frame update

    private void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }
    //Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
            

    }

    private void Update()
    {
        //Ignore collision on Layer 2
        Physics2D.IgnoreLayerCollision(gameObject.layer, 4);

    }



}


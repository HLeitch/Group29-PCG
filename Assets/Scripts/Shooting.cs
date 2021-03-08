using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] firePoint = new Transform[1];
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    

    // Update is called once per frame
    private void Start()
    {
        firePoint[0] = transform;
    }
    
       
    public void Shoot()
    {
        //Quaternion rotation = Quaternion.Euler(0f, 0f, -90f);
        foreach (Transform x in firePoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, x.position, x.rotation *Quaternion.Euler(0f, 0f, 180f));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            rb.AddForce(x.up * bulletForce, ForceMode2D.Impulse);
        }


        
    }

}


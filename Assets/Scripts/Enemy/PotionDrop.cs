using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] potions;

    public void drop()
    {
        int r1 = Random.Range(0, 3);
        if (r1 == 1)
        {
            int r2 = Random.Range(0, potions.Length);
            Instantiate(potions[r2], transform.position, transform.rotation);
        }
    }
}

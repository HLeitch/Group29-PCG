using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private UnityEvent effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Add particle & sound effects
        if (collision.gameObject.CompareTag("Player"))
        {
            effect.Invoke();
            Destroy(gameObject);
        }
    }
}

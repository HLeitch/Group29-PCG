﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    ChangeTile tile;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        tile = item.GetComponent<ChangeTile>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("Player"))
        {
            tile.ChangeSprite();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("Player"))
        {
            tile.ChangeSprite();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Switch"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeSprite();
            }
        }
        if (collision.gameObject.name == "WallCollider")
        {
            if (gameObject.name == "AboveLayer")
            {
                gameObject.GetComponentInParent<SpriteRenderer>().sortingLayerName = "Weapon";
                gameObject.GetComponentInParent<SpriteRenderer>().sortingOrder = 10;
                Debug.Log("interact above");
            }

            if (gameObject.name == "BelowLayer")
            {
                gameObject.GetComponentInParent<SpriteRenderer>().sortingLayerName = "Walls";

            }
        }
        
    }

  
    // Update is called once per frame
    public void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;

        gameObject.GetComponent<Collider2D>().enabled = false;
        
    }
}

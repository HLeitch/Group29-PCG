using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeSprite();
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Below Player";
           
        }
    
    }
    // Update is called once per frame
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}

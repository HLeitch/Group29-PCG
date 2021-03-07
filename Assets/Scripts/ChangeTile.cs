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

    private void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Switch"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                ChangeSprite();
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

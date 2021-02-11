using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIAbilities : MonoBehaviour
{

  

    Image abilitySprite;

    public Sprite testSprite;

    // Start is called before the first frame update
    void Start()
    {
        abilitySprite = GetComponent<Image>();
        abilitySprite.sprite = null;
    }

    /// <summary>
    /// Removes Current ability sprite from UI
    /// </summary>
    public void ClearSprite()
    {
        abilitySprite.sprite = null;
        abilitySprite.enabled = false;

    }

    /// <summary>
    /// Activates and shows a sprite representing the players current ability. 
    /// Takes a sprite from the abilities parameter
    /// </summary>
    /// <param name="newAbilitySprite"></param>
    public void NewAbilitySprite(Sprite newAbilitySprite)
    {
        abilitySprite.enabled = true;
        abilitySprite.sprite = newAbilitySprite;
    }




    private void Update()
    {



        //Debugging End
    }


}

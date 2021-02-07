using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIAbilities uiabilities;
    public UIHealthBar uihealthbar;
    public Sprite testSprite;

    /// <summary>
    /// Call when the player is given a weapon with a new ability
    /// </summary>
    /// <param name="newAbilitySprite"></param>
    public void newAbility(Sprite newAbilitySprite)
    {

        uiabilities.NewAbilitySprite(newAbilitySprite);

    }

    public void changeHealthBar(float value)
    {
        uihealthbar.ChangeHealth(value);

    }


    private void Update()
    {
        //Debugging
        //w key shows or removes a test sprite
        if (Input.GetKeyUp("w"))
        {
            uiabilities.NewAbilitySprite(testSprite);


        }
        if (Input.GetKeyUp("s"))
        {

            uiabilities.ClearSprite();

        }
        if (Input.GetKeyUp("space"))
        {
            uihealthbar.ChangeHealth(0.6f);

        }

    }
}

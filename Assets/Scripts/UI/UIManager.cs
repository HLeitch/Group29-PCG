using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIAbilities uiabilities;
    public UIHealthBar uihealthbar;
    public UIPlayerWeaponText uiPlayerWeaponText;
    public UIRoomText uiRoomText;
    public Sprite testSprite;

    public EnemyHealthBar EnemyHealthBarOriginal;
    public Enemy debuggingEnemy;

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

    public void NewPlayerWeapon(string weaponName)
    {
        uiPlayerWeaponText.DisplayNewWeaponName(weaponName);


    }

    public void ChangeRoomText(string text)
    {
        uiRoomText.ChangeText(text);

    }


    private void Update()
    {
        //Debugging
        //w key shows or removes a test sprite
        if (Input.GetKeyUp("w"))
        {
            newAbility(testSprite);


        }
        if (Input.GetKeyUp("s"))
        {

            uiabilities.ClearSprite();

        }
        if (Input.GetKeyUp("space"))
        {
            changeHealthBar(0.6f);

        }

        if (Input.GetKeyUp("t"))
        {
            NewPlayerWeapon("This is not a weapon. This is a debugger");

        }

        if (Input.GetKeyUp("r"))
        {
            ChangeRoomText("i am a fish");

        }

        if (Input.GetKeyUp("p"))
        {

            enemySpawn();
           
        }
      
    }

    /// <summary>
    /// Assigns a health Bar to an enemy
    /// </summary>
    /// <param name="e"></param>
    public void enemySpawn()
    {


        Enemy e = Instantiate<Enemy>(debuggingEnemy);

        EnemyHealthBar newEnemyHealthBar = Instantiate<EnemyHealthBar>(EnemyHealthBarOriginal,uihealthbar.transform);

        e.healthBar = newEnemyHealthBar;

    }
}

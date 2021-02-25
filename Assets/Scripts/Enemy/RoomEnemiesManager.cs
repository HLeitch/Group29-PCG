using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomEnemiesManager : MonoBehaviour
{

    public Enemy[] enemiesInRoom;
    public WeaponManager weaponManager;



    // Start is called before the first frame update
    void Start()
    {
        enemiesInRoom = GetComponentsInChildren<Enemy>(); 
        
        foreach (Enemy e in enemiesInRoom)
        {
            e.rem = this;
        }
    }

    public int currentEnemyCount()
    {

        int counter = 0;
        foreach(Enemy e in enemiesInRoom)
        {
            if(e != null)
            {
                counter++;

            }


        }
        return counter;

    }

    public void EnemyDied(Enemy enemy)
    {
        foreach(Enemy e in enemiesInRoom)
        {
            if(e.GetInstanceID() == enemy.GetInstanceID())
            {
               
            }

        }



    }

    public Weapon GiveWeapon()
    {
        if(weaponManager != null)
        {
            weaponManager.GenerateSword(this.transform.position);

            return null;

        }

        else
        {
            Debug.Log("NO WEAPON PROVIDED TO ENEMY");
            return null;
        }
    }

    private void Update()
    {
        Debug.Log("ENEMIES ON SCREEN =" + currentEnemyCount());
    }


}

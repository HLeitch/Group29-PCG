using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomEnemiesManager : MonoBehaviour
{

    public Enemy[] enemiesInRoom;
    public WeaponManager weaponManager;
    public bool active = false;
    public bool roomExplored = fale;
    public float timeTakenToClearRoom = 0;
    public int enemiesRemaining;
    RoomsManager myRoomManager;




    // Start is called before the first frame update
    void Start()
    {
        enemiesInRoom = GetComponentsInChildren<Enemy>();
        myRoomManager = GetComponentInParent<RoomsManager>();
        
        foreach (Enemy e in enemiesInRoom)
        {
            e.rem = this;
        }
    }

    /// <summary>
    /// Total Enemies not dead
    /// </summary>
    /// <returns></returns>
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

        if (counter == 0)
        {
            active = false;
            myRoomManager.timeTakenToClearLastRoom = timeTakenToClearRoom;
            myRoomManager.enemiesKilledPerSecondInLastRoom = enemiesInRoom.Length / timeTakenToClearRoom;
            enemiesRemaining = 0;

        }
         return counter;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //player enters room
        if(other.gameObject.layer == 8)
        {
            active = true;
            roomExplored = true;
            foreach(Enemy e in enemiesInRoom)
            {
                e.gameObject.SetActive(true);
                

            }

        }
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

    public void EnemyDamaged(float damageTaken)
    {
        myRoomManager.enemyDamaged(damageTaken);

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
        if(active)
        {
            timeTakenToClearRoom += Time.deltaTime;
            enemiesRemaining = currentEnemyCount();
        }
    }


}

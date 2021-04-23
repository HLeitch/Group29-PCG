using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomEnemiesManager : MonoBehaviour
{

    public List<Enemy> enemiesInRoom;
    public WeaponManager weaponManager;
    public bool active = false;
    public bool roomExplored = false;
    public float timeTakenToClearRoom = 0;
    public int enemiesRemaining;
    RoomEnemyDataGatherer myDataGatherer;
    FogOfWar fogOfWarComponent;




    // Start is called before the first frame update
    void Start()
    {
        
        myDataGatherer = GetComponentInParent<RoomEnemyDataGatherer>();
        fogOfWarComponent = GetComponent<FogOfWar>();
        enemiesInRoom = fogOfWarComponent.enemies;

        foreach (Enemy e in enemiesInRoom)
        {
            e.rem = this;
        }
    }

    private void Awake()
    {
        

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
            myDataGatherer.timeTakenToClearLastRoom = timeTakenToClearRoom;
         myDataGatherer.enemiesKilledPerSecondInLastRoom = enemiesInRoom.Count / timeTakenToClearRoom;
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
                if (e != null)
                    {
                    e.gameObject.SetActive(true);
                }

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
        myDataGatherer.enemyDamaged(damageTaken);

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

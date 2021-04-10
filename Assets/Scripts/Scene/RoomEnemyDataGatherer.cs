using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyDataGatherer : MonoBehaviour
{
    [SerializeField]
    RoomEnemiesManager[] roomEnemyObjects;
    PlayerCombat pc;

    public int totalEnemiesInLevel;
    float startTime;
    public float timeTakenToClearLastRoom=999.9f;
    public float enemiesKilledPerSecondInLastRoom = 999.9f;

    int EnemiesKilledInLastPeriod = 0;

     int playerHealthLastPeriod = 0;
   public int playerHealthChangeLastPeriod = 0;

    public int enemiesKilledinLastPeriod;
    int enemiesKilledBeforeThisPeriod;

    public float damageInLastPeriod;
    float damageCounter = 0;
    float periodTimer;
    public float maxPeriodTimer = 20f;


    // Start is called before the first frame update
    void Start()
    {
        roomEnemyObjects = GetComponentsInChildren<RoomEnemiesManager>();

        totalEnemiesInLevel = TotalEnemies();

        startTime = Time.time;
        periodTimer = maxPeriodTimer;

        pc = FindObjectOfType<PlayerCombat>();
        playerHealthLastPeriod = pc.getHealth();

        Debug.Log("Time " + startTime);
    }

    public void enemyDamaged(float damageTaken)
    {
        damageCounter -= damageTaken;

    }


    public int EnemiesKilled()
    {
        int stillLiving = 0;

        foreach (RoomEnemiesManager r in roomEnemyObjects)
        {
            
             { stillLiving += r.currentEnemyCount(); 
            
            }


        }
        return totalEnemiesInLevel - stillLiving;

    }
    public int TotalEnemies()
    {
        int totalEnemies = 0;

        foreach (RoomEnemiesManager r in roomEnemyObjects)
        {

            { totalEnemies += r.enemiesInRoom.Count; }


        }
        return totalEnemies;
    }

    public int TotalActiveEnemies()
    {

        int returnValue = 0;

        foreach(RoomEnemiesManager r in roomEnemyObjects)
        {
            //Counts all living enemies from active rooms

            returnValue+= r.enemiesRemaining;
            


        }
        return returnValue;


    }

    public float PercentageEnemiesKilled()
    {

    
        float floatTotalEnemiesInLevel = totalEnemiesInLevel;

        float value =  (floatTotalEnemiesInLevel- TotalActiveEnemies())/ floatTotalEnemiesInLevel;
        return value;

    }

    /// <summary>
    /// Over Time where Time is in seconds since start
    /// </summary>
    /// <returns></returns>
    public float EnemiesKilledPerSecond()
    {
        float enemiesKilled = EnemiesKilled();

        return (enemiesKilled / (Time.time - startTime));
    }

   public void DebugMe()
    {
        Debug.Log("Active Enemies who are active: " + TotalActiveEnemies() +
            "\n Total Enemies: " + TotalEnemies() +
            "\n Percentage Enemies Killed : " + PercentageEnemiesKilled() +
            "\n Rate of Enemies Killed : " + EnemiesKilledPerSecond() +
            "\n Time taken in last room: " + timeTakenToClearLastRoom +
            "\n Rate of enemy kill in last room" + enemiesKilledPerSecondInLastRoom +
            "\n Enemy damage in last 20 seconds: " + damageInLastPeriod);


    }



    // Update is called once per frame
    void Update()
    {


        periodTimer -= Time.deltaTime;
        if(periodTimer <= 0)
        {
            periodTimer = maxPeriodTimer;
            damageInLastPeriod = damageCounter;
            damageCounter = 0;

            enemiesKilledinLastPeriod = (EnemiesKilled() - enemiesKilledBeforeThisPeriod);

            enemiesKilledBeforeThisPeriod = enemiesKilledinLastPeriod;

            playerHealthChangeLastPeriod = playerHealthLastPeriod - pc.getHealth();
        }

        if(Input.GetKeyDown("l"))
        {
            DebugMe();

        }

    }
}

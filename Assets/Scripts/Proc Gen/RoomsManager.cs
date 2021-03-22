using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    [SerializeField]
    RoomEnemiesManager[] roomEnemyObjects;

    public int totalEnemiesInLevel;
    float startTime;
    public float timeTakenToClearLastRoom=999.9f;
    public float enemiesKilledPerSecondInLastRoom = 999.9f;

    public float damageInLast20Seconds;
    float damageCounter = 0;
    float damageTimer;
    public float maxDamageTimer = 20f;


    // Start is called before the first frame update
    void Start()
    {
        roomEnemyObjects = GetComponentsInChildren<RoomEnemiesManager>();

        totalEnemiesInLevel = TotalEnemies();

        startTime = Time.time;
        damageTimer = maxDamageTimer;

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
            if(r.active == true) { returnValue += r.currentEnemyCount(); } 


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
            "\n Enemy damage in last 20 seconds: " + damageInLast20Seconds);


    }



    // Update is called once per frame
    void Update()
    {


        damageTimer -= Time.deltaTime;
        if(damageTimer <= 0)
        {
            damageTimer = maxDamageTimer;
            damageInLast20Seconds = damageCounter;
            damageCounter = 0;

        }

        if(Input.GetKeyDown("l"))
        {
            DebugMe();

        }

    }
}

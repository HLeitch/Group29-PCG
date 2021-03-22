using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationData : MonoBehaviour
{

    [SerializeField]
    RoomEnemyDataGatherer roomsDataGatherer;
    








    //Enemy Data ////////////
    /////////////////////////
    

    public int TotalActiveEnemies()
    {
        return roomsDataGatherer.TotalActiveEnemies();
    }
   
    public int TotalEnemiesInLevel()
    {
        return roomsDataGatherer.totalEnemiesInLevel;
    }
    
    public float PercentageEnemiesKilled()
    {
        return roomsDataGatherer.PercentageEnemiesKilled();
    }
    public float TimeTakenToCompleteLastRoom()
    {

        return roomsDataGatherer.timeTakenToClearLastRoom;
    }

    public float RateOfEnemyKillInLastRoom()
    {
        return roomsDataGatherer.enemiesKilledPerSecondInLastRoom;
    }

    public float RateOfEnemiesKilled()
    {
        return roomsDataGatherer.EnemiesKilledPerSecond();
    }

    public float EnemyDamageInLastPeriodOfTime()
    {
        return roomsDataGatherer.damageInLast20Seconds;
    }

    //Enemy Data Ends////////
    /////////////////////////
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}

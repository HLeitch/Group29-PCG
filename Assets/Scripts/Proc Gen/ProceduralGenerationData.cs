using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationData : MonoBehaviour
{

    [SerializeField]
    RoomsManager roomsManager;
    








    //Enemy Data ////////////
    /////////////////////////
    

    public int TotalActiveEnemies()
    {
        return roomsManager.TotalActiveEnemies();
    }
   
    public int TotalEnemiesInLevel()
    {
        return roomsManager.total;
    }
    
    public float PercentageEnemiesKilled()
    {
        return roomsManager.PercentageEnemiesKilled();
    }
    public float TimeTakenToCompleteLastRoom()
    {

        return roomsManager.timeTakenToClearLastRoom;
    }

    public float RateOfEnemyKillInLastRoom()
    {
        return roomsManager.enemiesKilledPerSecondInLastRoom;
    }

    public float RateOfEnemiesKilled()
    {
        return roomsManager.EnemiesKilledPerSecond();
    }

    public float EnemyDamageInLastPeriodOfTime()
    {
        return roomsManager.damageInLast20Seconds;
    }

    //Enemy Data Ends////////
    /////////////////////////
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}

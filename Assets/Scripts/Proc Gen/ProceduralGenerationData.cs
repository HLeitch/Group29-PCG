using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationData : MonoBehaviour
{

    [SerializeField]
    RoomEnemyDataGatherer roomsDataGatherer;
    RoomManager rm;
    WeaponGeneration wg;

    
    float sumOfPerformances = 0;
    int weaponChanges= 0;



    private void Awake()
    {
        rm = FindObjectOfType<RoomManager>();
        wg = FindObjectOfType<WeaponGeneration>();
    }


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
        return roomsDataGatherer.damageInLastPeriod;
    }

    //Enemy Data Ends////////
    /////////////////////////
    
   

    // Update is called once per frame
    void Update()
    {
        
    }

    float TypePlayerPerformance()
    {
        float playerPerformance = 0;

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 100f, 0f, 1f);

        float enemiesKilledPerformance = Mathf.Clamp(roomsDataGatherer.enemiesKilledinLastPeriod / 10f, 0, 1);

        float playerhealthPerformance = Mathf.Clamp(roomsDataGatherer.playerHealthChangeLastPeriod / 10f, 0, 1);

        playerPerformance = damageGivenPerformance + enemiesKilledPerformance - playerhealthPerformance;

        averagePlayerPerformance

        return playerPerformance;
    }

    float HiltPlayerPerformance()
    {
        float performance = 0;

        //enemy count//
        //float timePerformance = TimeTakenToCompleteLastRoom()/(5*roomsDataGatherer.;
        
        float enemiesKilledPerformance = Mathf.Clamp(roomsDataGatherer.enemiesKilledPerSecondInLastRoom / 10f, 0, 1);

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 100f, 0f, 1f);

        performance = enemiesKilledPerformance + damageGivenPerformance;

        return performance;

    }

    float BladePlayerPerformance()
    {
        float performance = 0;

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 100f, 0f, 1f);

    float successfulSwings = wg.swingsTook;
        return 0;
    }

    public float averagePlayerPerformance()
    {
         
    }
}

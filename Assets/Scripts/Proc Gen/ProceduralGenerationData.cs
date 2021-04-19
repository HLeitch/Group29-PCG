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
    WeaponManager weaponManager;

    
    float sumOfPerformances = 0;
    int numOfPerfSamples= 0;


    float testTimer = 0.0f;
    public float maxTestTimer;
    


    private void Awake()
    {
        roomsDataGatherer.pg = this;

        rm = FindObjectOfType<RoomManager>();
        wg = FindObjectOfType<WeaponGeneration>();
        weaponManager = FindObjectOfType<WeaponManager>();
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

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 50f, 0f, 1f);

        float enemiesKilledPerformance = Mathf.Clamp(roomsDataGatherer.enemiesKilledinLastPeriod / 10f, 0, 1);

        float playerhealthPerformance = Mathf.Clamp(roomsDataGatherer.playerHealthChangeLastPeriod / 30f, 0, 1);

        playerPerformance =Mathf.Clamp((damageGivenPerformance + enemiesKilledPerformance - playerhealthPerformance),0,1);

        //Debug.Log("performance (last) = " + playerPerformance);
        //Debug.Log("DamageGivenPerformance = " + damageGivenPerformance);

        sumOfPerformances += playerPerformance;

        float avgPerformance = sumOfPerformances / numOfPerfSamples;

        Debug.Log("avgPerformance for type of weapon (overall) = " + avgPerformance);

        numOfPerfSamples++;


        if (numOfPerfSamples > 1)
        { return avgPerformance;
    }
        else
        { return 0; }
        
    }

    float HiltPlayerPerformance()
    {
        float performance = 0;

        //enemy count//
        float timePerformance = Mathf.Clamp(TimeTakenToCompleteLastRoom()/roomsDataGatherer.enemiesKilledPerSecondInLastRoom * 10f,0f,1f);
        Debug.Log("timePerformance = " + timePerformance);


        float enemiesKilledPerformance = Mathf.Clamp(roomsDataGatherer.enemiesKilledPerSecondInLastRoom, 0f, 1f);
        Debug.Log("enemiesKilledPerformance = " + enemiesKilledPerformance);

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 100f, 0f, 1f);
        Debug.Log("damageGivenPerformance = " + damageGivenPerformance);

        performance = enemiesKilledPerformance + damageGivenPerformance + timePerformance;

        Debug.Log("enemy Based Performance (hilt) = " + performance);

        return Mathf.Clamp(performance,0,1);

    }

    float BladePlayerPerformance()
    {
        float performance = 0;

        float damageGivenPerformance = Mathf.Clamp(EnemyDamageInLastPeriodOfTime() / 100f, 0f, 1f);


        performance = damageGivenPerformance;
        Debug.Log("damageGivenPerformance = " + damageGivenPerformance);
 
        return performance;
    }

    public void newData()
    {





        weaponManager.GiveWeapon(TypePlayerPerformance(), BladePlayerPerformance(), HiltPlayerPerformance());

    }

}

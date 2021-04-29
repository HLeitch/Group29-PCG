using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGeneration : MonoBehaviour
{
    public float timeTotal = 0;
    public float timeSinceSwitch = 0;
    public int enemiesKilled = 0;
    public int swingsTook = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTotal += Time.deltaTime;
        timeSinceSwitch += Time.deltaTime;
        
    }

    public void UpdateSwitchTime()
    {
        timeSinceSwitch = 0;
    }    

    public void UpdateEnemiesKilled()
    {
        enemiesKilled++;
    }

    public void UpdateSwingsTook()
    {
        swingsTook++;
    }
}

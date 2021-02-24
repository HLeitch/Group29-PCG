using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemiesManager : MonoBehaviour
{

    public Enemy[] enemiesInRoom;




    // Start is called before the first frame update
    void Start()
    {
        enemiesInRoom = GetComponentsInChildren<Enemy>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

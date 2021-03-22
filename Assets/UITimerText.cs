using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimerText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMesh;
    public float timer;
    //e.g 'room' or 'dungeon'
    public string descriptorText = "Time";
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        timer += Time.deltaTime;
            
        DisplayTime_MS(timer);
        
    }
    void DisplayTime_MS(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}

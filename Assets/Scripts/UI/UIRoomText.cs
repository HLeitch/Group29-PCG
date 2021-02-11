using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRoomText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    //e.g 'room' or 'dungeon'
    public string descriptorText = "Room"; 
     void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();


        ChangeText("1");
    }

    /// <summary>
    /// Adds new text underneath the description text
    /// </summary>
    /// <param name="text"></param>
    public void ChangeText(string text)
    {
        textMesh.text = descriptorText + "\n" + text;

    }


}

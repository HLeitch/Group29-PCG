using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerWeaponText : MonoBehaviour
{


    public TextMeshProUGUI textMesh;

    float typingTimer;
    public float TimeBetweenTyping;
    public float maxPauseTime = 3.0f;
    float pauseTime;

    /// <summary>
    /// when true, starts the typing process
    /// </summary>
    bool newWeapon = false;

    /// <summary>
    /// Game is currently typing the name of the players weapon
    /// </summary>
    bool typing = false;

    /// <summary>
    /// Game is currently paused, showing the full weapon name
    /// </summary>
    bool paused = false;

    /// <summary>
    /// Game is currently deleting the name of the players weapon
    /// </summary>
    bool backspacing = false;

    public string weaponName;



    int typingIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();

        

       

    }

    // Update is called once per frame
    void Update()
    {

        // DEBUGGING
        if (newWeapon)
        {
            
            TypingEffect();

        }
    }



    public void DisplayNewWeaponName(string weaponName)
    {
        typing = true;
        newWeapon = true;
        this.weaponName = weaponName;

    }

    private void TypingEffect()
    {

        typingTimer -= Time.deltaTime;

        if (typing && textMesh.text.Length < weaponName.Length)
        {
            if (typingTimer < 0)
            {
                //Add the next character of weapon name to text on screen
                textMesh.maxVisibleCharacters = typingIndex+1;
                textMesh.text += weaponName[textMesh.text.Length].ToString();
                typingIndex++;
                
                typingTimer = TimeBetweenTyping;
            }
        }

        if (typing && textMesh.text.Length >= weaponName.Length)
        {
            typing = false;
            paused = true;
            pauseTime = maxPauseTime;

        }
        if (paused)
        {
            pauseTime -= Time.deltaTime;

            if (pauseTime <= 0)
            {
                backspacing = true;
                paused = false;
                typingTimer = 0;

            }

        }

        if (backspacing)
        {
            typingTimer -= Time.deltaTime;
            if (typingIndex != 0)
            {
                if (typingTimer <= 0)
                {
                    typingIndex--;
                    textMesh.maxVisibleCharacters = typingIndex;
                    typingTimer = TimeBetweenTyping;

                }
            }
            else
            {
                typingIndex++;
                backspacing = false;
                newWeapon = false;

            }

        }


    }
}

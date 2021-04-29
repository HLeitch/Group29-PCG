using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void Exit()
    {
        Fade fade = GameObject.Find("Fade").GetComponent<Fade>(); // Get current scene's fade object,

        StartCoroutine(fade.toBlack((finished) => {  // Start a coroutine to fade the screen to black.
            if (finished) Application.Quit();        // When it finishes, exit the game
        }));
    }

    public void Sound()
    {
        SoundManager.playSound("ui_sound", 1, Random.Range(0.75f, 1.25f));
    }
}

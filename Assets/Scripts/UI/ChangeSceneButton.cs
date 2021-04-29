using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Used by the ChangeSceneButton prefab
/// </summary>
public class ChangeSceneButton : MonoBehaviour
{
    /// <summary>
    /// Loads a scene, saving data before hand if neccessary.
    /// </summary>
    /// <param name="sceneName">
    /// The name of the scene to load - must be added in the build settings!
    /// </param>
    public void ChangeScene(string sceneName)
    {
        SoundManager.playSound("ui_sound", 1, 1.5f);

        // Save neccessary data (score, highscore, etc...) here
        Fade fade = GameObject.Find("Fade").GetComponent<Fade>(); // Get current scene's fade object,

        StartCoroutine(fade.toBlack((finished) => {          // Start a coroutine to fade the screen to black.
            if (finished) SceneManager.LoadScene(sceneName); // When it finishes, load the new scene
        }));
    }

    public void Sound()
    {
        SoundManager.playSound("ui_sound", 1, Random.Range(0.75f, 1.25f));
    }
}

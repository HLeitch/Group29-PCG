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
        // Save neccessary data (score, highscore, etc...) here
        Fade fade = GameObject.FindObjectOfType<Fade>(); // Get current scene's fade object,

        StartCoroutine(fade.toBlack((finished) => {          // Start a coroutine to fade the screen to black.
            if (finished) SceneManager.LoadScene(sceneName); // When it finishes, load the new scene
        }));
    }
}

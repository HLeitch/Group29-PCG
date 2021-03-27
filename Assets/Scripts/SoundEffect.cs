using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Added Sound Effect GameObjects to delete them once their audio clip has finished.
/// </summary>
public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.clip.length == audioSource.time) // Once the clip has finished playing,
        {
            if (!audioSource.loop) Destroy(gameObject); // Destroy this object.
        }
    }

    /// <summary>
    /// Stops the audio clip looping (when it stops, this game object is destroyed - see Update)
    /// </summary>
    public void stopLoop()
    {
        audioSource.loop = false;
        name = name + " Stopping..."; // The name of the game object must be changed or else another loop using the same clip cannot start again while this is running
    }
}

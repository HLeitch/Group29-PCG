using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static class for playing sound effects.
/// e.g. SoundManager.playSound("coin", 0.5f, overlap: false)
/// This will play the coin sound effect at 50% volume,
/// provided a coin sound effect is not already playing.
/// </summary>
public static class SoundManager
{
    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    /// <param name="clipName">
    /// The filename of the sound effect to be played. Must be placed in the Resources/Sounds folder, extension not needed.
    /// </param>
    /// <param name="volume">
    /// The volume the sound will play at, between 0 and 1 (inclusive). Default = 1.
    /// </param>
    /// <param name="pitch">
    /// The pitch the sound will play at, between 0 and 1 (inclusive). Default = 1.
    /// </param>
    /// <param name="loop">
    /// Whether or not the sound effect should start looping. Default = false.
    /// </param>
    /// <param name="overlap">
    /// Whether or not the sound effect should overlap other sound effects of the same name. Default = true.
    /// </param>
    /// <returns>
    /// Whether or not the sound played successfully.
    /// </returns>
    public static bool playSound(string clipName, float volume = 1.0f, float pitch = 1.0f, bool loop = false, bool overlap = true)
    {
        if ((loop || !overlap) && GameObject.Find(clipName + " Sound Effect") != null) return false; // If the clip is not meant to overlap or is meant to loop, stop that from happening.

        string folder = "Sounds"; // Folder name withing Resources
        AudioClip soundEffect = Resources.Load<AudioClip>(folder + "/" + clipName); // The sound effect's audio clip
        if (soundEffect != null) // If the file exists,
        {
            GameObject soundEffectObject = new GameObject(clipName + " Sound Effect"); // Create a new game object.
            
            AudioSource audioSource = soundEffectObject.AddComponent<AudioSource>(); // Add an AudioSource component to it,
            audioSource.clip = soundEffect; // Set the AudioSource attributes to the parameters passed into this function,
            audioSource.volume = volume * PlayerPrefs.GetFloat("Sound", 0.5f);
            audioSource.pitch = pitch;
            audioSource.loop = loop;

            soundEffectObject.AddComponent<SoundEffect>(); // Add a SoundEffect script to the object
            audioSource.Play(); // Start playing the sound effect
            return true; // Report a success.
        }
        else // If the file doesn't exist,
        {
            Debug.LogError("Clip '" + clipName + "' not found in '" + folder + "' folder."); // Show an error in the console,
            return false; // Report a failure.
        }
    }

    /// <summary>
    /// This function allows the stopping of a looped sound effect. Has no effect on one-time effects.
    /// </summary>
    /// <param name="clipName">
    /// The name of the sound effect to be stopped.
    /// </param>
    public static void stopSoundLoop(string clipName)
    {
        GameObject soundEffect = GameObject.Find(clipName + " Sound Effect"); // Find the game object which is playing the looped sound (assume only 1 exists)
        if (soundEffect != null) soundEffect.GetComponent<SoundEffect>().stopLoop(); // If the sound is being played, stop it looping
    }
}

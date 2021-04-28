using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private Slider slider;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        text = transform.Find("Value").GetComponent<Text>();
        transform.Find("Label").GetComponent<Text>().text = gameObject.name;
        slider.value = PlayerPrefs.GetFloat(gameObject.name);
        setValueText(slider.value);
        
    }

    public void UpdateSlider()
    {
        setValueText(slider.value);
        PlayerPrefs.SetFloat(gameObject.name, slider.value);
        foreach (AudioSource audioSource in GameObject.FindObjectsOfType<AudioSource>())
        {
            if (audioSource.gameObject.name == "MusicManager")
            {
                audioSource.volume = PlayerPrefs.GetFloat("Music");
            }
            else
            {
                audioSource.volume = PlayerPrefs.GetFloat("Sound");
            }
        }

        SoundManager.playSound("ui_sound", 1, 1, false, false);
    }

    private void setValueText(float value)
    {
        text.text = Mathf.RoundToInt(value * 100).ToString() + "%";
    }
}

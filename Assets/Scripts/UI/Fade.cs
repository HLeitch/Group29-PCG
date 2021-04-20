using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("Any faster than 8 and it stops working...")]
    [SerializeField]
    private float speed;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(toClear((finished1) => { }));
        }

    public IEnumerator toClear(System.Action<bool> callback) // Callback allows for returning of variable (in this case, whether or not the coroutine has finished)
    {
        for (float i = image.color.a; i >= 0; i -= speed * Time.deltaTime) // Repeat many times for a smooth fade,
        {
            Color new_color = image.color; // Get current colour,
            new_color.a = i; // Reduce its opacity,
            image.color = new_color; // Update the colour with our new one,
            if (image.color.a <= 0.05f) GetComponent<Image>().enabled = false; // If it is practically invisible, deactivate it.

            yield return null;
        }
        callback(true); // Return true (coroutine has finished)
    }

    public IEnumerator toBlack(System.Action<bool> callback) // Callback allows for returning of variable (in this case, whether or not the coroutine has finished)
    {
        GetComponent<Image>().enabled = true;
        for (float i = image.color.a; i <= 1; i += speed * Time.deltaTime) // Repeat many times for a smooth fade,
        {
            Color new_color = image.color; // Get current colour,
            new_color.a = i; // Reduce its opacity,
            image.color = new_color; // Update the colour with our new one, 

            yield return null;
        }
        callback(true); // Return true (coroutine has finished)
    }
}

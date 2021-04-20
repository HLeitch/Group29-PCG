using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    public PlayerCombat playerCombat;
    private Fade fade;
    private Fade deathImage;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        deathImage = GameObject.Find("DeathImage").GetComponent<Fade>();
        //playerCombat = GameObject.Find("Player 1").GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCombat.getHealth() <= 0)
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        StartCoroutine(fade.toBlack((finished1) => {            // Start a coroutine to fade the screen to black.

            StartCoroutine(deathImage.toBlack((finished2) => {   // When it finishes, fade the death image in,
                
                StartCoroutine(deathImage.toClear((finished3) => {   // When it finishes, fade the death image in,
                    if (finished3) SceneManager.LoadScene("Start"); // When that finishes, load the menu
                }));

            }));

        }));

        
    }
}

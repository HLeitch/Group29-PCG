using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    [SerializeField]
    private int noOfEnemies;

    private Fade winImage;

    // Start is called before the first frame update
    void Start()
    {
        winImage = GameObject.Find("WinImage").GetComponent<Fade>();

        // Expected this \/ to return 19, but it returned 15 :/ a little worrying :P
        //noOfEnemies = FindObjectOfType<RoomEnemyDataGatherer>().totalEnemiesInLevel; 
    }

    // Update is called once per frame
    void Update()
    {
        if (noOfEnemies == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex+1 == SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("GAME OVER, you win!!!");
                ChangeSceneTo("Start");
            }
            else
            {
                Debug.Log("GAME OVER, next level");
                ChangeSceneTo(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void kill()
    {
        noOfEnemies--;
    }

    private void ChangeSceneTo(int sceneId)
    {
        Fade fade = GameObject.Find("Fade").GetComponent<Fade>();

        StartCoroutine(fade.toBlack((finished1) => {            // Start a coroutine to fade the screen to black.

            StartCoroutine(winImage.toBlack((finished2) => {   // When it finishes, fade the death image in,

                StartCoroutine(winImage.toClear((finished3) => {   // When it finishes, fade the death image in,
                    if (finished3) SceneManager.LoadScene(sceneId); // When that finishes, load the menu
                }));

            }));

        }));
    }

    private void ChangeSceneTo(string sceneName)
    {
        Fade fade = GameObject.Find("Fade").GetComponent<Fade>();

        StartCoroutine(fade.toBlack((finished1) => {            // Start a coroutine to fade the screen to black.

            StartCoroutine(winImage.toBlack((finished2) => {   // When it finishes, fade the death image in,

                StartCoroutine(winImage.toClear((finished3) => {   // When it finishes, fade the death image in,
                    if (finished3) SceneManager.LoadScene(sceneName); // When that finishes, load the menu
                }));

            }));

        }));
    }
}

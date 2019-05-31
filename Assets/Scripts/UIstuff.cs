using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIstuff : MonoBehaviour
{
    public Text keysToCollect;
    public Text playerLives;
    public Text noMoreLives;
    public Text pressN;

    public Text pause;
    bool isPaused;

    public Text timer;
    public int timeLeft;

    void Start()
    {
        timeLeft = 6;
        noMoreLives.text = "";
        pressN.text = "";
        StartCoroutine(StartCountdown());
        isPaused = false;
        pause.text = "";
    }

    void Update()
    {
        keysToCollect.text = "" + PlayerController.keysLeftToCollect;
        playerLives.text = "" + PlayerController.playerHealth;

        if (PlayerController.playerHealth <= 0)
        {
            noMoreLives.text = "You Died. Press Y To Restart.";
            pressN.text = "N to Exit.";

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log(isPaused);
            if (isPaused == false)
            {
                pause.text = "Paused";
                isPaused = true;
                Time.timeScale = 0;
            }

            else if (isPaused)
            {
                pause.text = "";
                isPaused = false;
                Time.timeScale = 1;
            }
        }
        
    }

    IEnumerator StartCountdown()
    {
        while (timeLeft >= 0)
        {
            yield return new WaitForSeconds(1);
            --timeLeft ;
            timer.text = timeLeft.ToString();

            if (timeLeft <= 0)
            {
                timer.text = "";
            }
        }
    }
}

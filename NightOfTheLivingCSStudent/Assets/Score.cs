using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int sleepMins = 300;
    public Enemy spookyboi;
    public bool sleeping;
    public bool running;
    public Text scoreText;
    float timeElapsed = 0;

    public bool playerWon = false;

    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = sleepMins + " Minutes";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)) {
            running = true;
            spookyboi.setPlayerPos(GetComponent<Transform>().position);
        }
        else {
            running = false;
        }
        if(sleeping) {
            timeElapsed += Time.deltaTime;
            if(timeElapsed > 1) {
                sleepMins -= 1;
                timeElapsed -= 1;
                scoreText.text = sleepMins + " Minutes";
            }

            if(sleepMins <= 0) {
                Time.timeScale = 0;
                winScreen.SetActive(true);
                playerWon = true;
            }
        }
    }

    public void setSleep(bool sleepState) {
        sleeping = sleepState;
        timeElapsed = 0;
        spookyboi.setPlayerPos(GetComponent<Transform>().position);
    }
}

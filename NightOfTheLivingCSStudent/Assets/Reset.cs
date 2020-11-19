using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public Enemy bad;
    public Score good;

    public GameObject pauseMenu;

    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
            if(bad.won || good.playerWon) {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
            // else if(paused) {
            //     pauseMenu.SetActive(false);
            //     Time.timeScale = 1;
            //     paused = false;
            // }
            // else {
            //     pauseMenu.SetActive(true);
            //     paused = true;
            //     Time.timeScale = 0;
            // }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Interaction : MonoBehaviour
{
    public Text interact;
    public GameObject sleepScreen;
    public bool canInteract = false;
    public bool interacting = false;
    FirstPersonController movement;

    float timeSinceSleep = 0;

    bool forcedSleep = false;

    Score scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GetComponent<Score>();
        movement = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!interacting) {
            timeSinceSleep += Time.deltaTime;
        }

        if(forcedSleep) {
            timeSinceSleep += Time.deltaTime;
            if(timeSinceSleep >= 5) {
                setupWake();
                forcedSleep = false;
                interact.text = "";
                timeSinceSleep = 0;
            }
        }

        if(timeSinceSleep > 120) {
            setupSleep();
            interact.text = "Sleeping...";
            forcedSleep = true;
            timeSinceSleep = 0; 
        }

        if(Input.GetButtonDown("Interact") && canInteract && !interacting) {
            setupSleep();
            interact.text = "Press E to Wake";
        }
        else if(Input.GetButtonDown("Interact") && canInteract && interacting && !forcedSleep) {
            setupWake();
            interact.text = "Press E to Sleep";
        }
    }

    void setupSleep() {
        interacting = true;
            scoreKeeper.setSleep(true);
            sleepScreen.SetActive(true);
            movement.enabled = false;
            timeSinceSleep = 0;
    }

    public void setupWake() {
        interacting = false;
        scoreKeeper.setSleep(false);
        sleepScreen.SetActive(false);
        movement.enabled = true;
    }

    public void isNearInteractable(bool near) {
        canInteract = near;
        if(near) {
            interact.text = "Press E to Sleep";
        }
        else {
            interact.text = "";
        }
    }
}
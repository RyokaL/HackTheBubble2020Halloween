using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour
{

    Vector3 playerPos = new Vector3(0, 0, 0);
    float moveSpeed = 2;

    public bool won = false;

    Transform thisPos;

    public GameObject camSpot;    

    public GameObject loseScreen;
    public FirstPersonController movement;
    // Start is called before the first frame update
    void Start()
    {
        thisPos = GetComponent<Transform>();
        GetComponentInChildren<Renderer>().enabled = false;
    }

    void randomiseMoveSpeed() {
        moveSpeed = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 100) < 20) {
            randomiseMoveSpeed();
        }

        if(!won) {
            float divisor = ((playerPos - thisPos.position).magnitude);
            if(divisor == 0) {

            }
            else {
                Vector3 move = (playerPos - thisPos.position) / ((playerPos - thisPos.position).magnitude) * moveSpeed * Time.deltaTime;
            
                thisPos.position += move;
                transform.LookAt((move - thisPos.position));
            }

        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player")) {
            triggerEnd(other);
        }
    }

    void triggerEnd(Collider other) {
         Score scoreKeeper = other.GetComponent<Score>();
           if(scoreKeeper.sleeping || scoreKeeper.running) {
               other.GetComponent<Interaction>().setupWake();
               movement.enabled = false;
               won = true;
               GetComponentInChildren<Renderer>().enabled = true;
               camSpot.transform.rotation = transform.rotation;
               GameObject.FindGameObjectWithTag("MainCamera").transform.position = camSpot.transform.position;
               GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = transform.rotation;
               loseScreen.SetActive(true);
           }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag.Equals("Player")) {
           triggerEnd(other);
        }
    }

    public void setPlayerPos(Vector3 pos) {
        playerPos = pos;
    }
}

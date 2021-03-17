using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool cleared;
    public int numberOfEnemies;
    public GameObject timerCanvas;
    private TimeManager timeManager;

    private bool closedDoors;
    private GameObject topDoor;
    private GameObject bottomDoor;
    private GameObject leftDoor;
    private GameObject rightDoor;
    private List<GameObject> doorList;
    private Animator anim;


    
    void Start()
    {
        timeManager = timerCanvas.GetComponent<TimeManager>();
        cleared = false;
        closedDoors = true;
        foreach (Transform child in transform){
            if (child.name == "TopDoor"){
                topDoor = child.gameObject;
            }
            else if (child.name == "BottomDoor"){
                bottomDoor = child.gameObject;
            }
            else if (child.name == "LeftDoor"){
                leftDoor = child.gameObject;
            }
            else if (child.name == "RightDoor"){
                rightDoor = child.gameObject;
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemies <= 0){
            timeManager.stop = true;
            cleared = true;
        }
        if (cleared && closedDoors){
            if (leftDoor){anim = leftDoor.GetComponent<Animator>(); anim.SetBool("openDoors", true);}
            if (rightDoor){anim = rightDoor.GetComponent<Animator>(); anim.SetBool("openDoors", true);}
            if (topDoor){anim = topDoor.GetComponent<Animator>(); anim.SetBool("openDoors", true);}
            if (bottomDoor){anim = bottomDoor.GetComponent<Animator>(); anim.SetBool("openDoors", true);}
            closedDoors = false;
        }
    }

    public void killedEnemy(){
        numberOfEnemies -= 1;
    }
}

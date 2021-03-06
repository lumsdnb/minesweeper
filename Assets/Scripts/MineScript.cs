﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{


    public GameObject screw1;
    public GameObject screw2;
    public GameObject firstFuse;
    public int mineState = 0;
    public bool isArmed = true;

    

    public void setState(int state)
    {
        mineState = state;
    }

    void Update()
    {

        switch (mineState)
        {
        case 1:
            //first screw removed
            // screw1.SetActive(false);
                firstFuse.GetComponent<Rigidbody>().useGravity = true;
                SceneLogic.ScrewOneAction.Invoke();
                break;
        case 2:
            //second screw removed
            // screw2.SetActive(false);
            break;
        case 3:
                //mine hit 3 times with hammer
                //todo: turn on rigidbody for fuse
                SceneLogic.ScrewTwoAction.Invoke();
                break;
            default:
            break;
        }
    }
}

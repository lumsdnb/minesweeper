using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{


    public GameObject screw1;
    public GameObject screw2;
    public int mineState=0;

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
            screw1.SetActive(false);
            break;
        case 2:
            //second screw removed
            screw2.SetActive(false);
            break;
        case 3:
            //mine hit 3 times with hammer
            //todo: turn on rigidbody for fuse
            break;
            default:
            break;
        }
    }
}

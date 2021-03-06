﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThisPhysics : MonoBehaviour
{
    public bool unscrewed = false;
    public int screwNum = 0;
    public GameObject mine;
    MineScript ReferenceScript;

    void Start()
    {
        ReferenceScript = mine.GetComponent<MineScript>();
    }

    void LateUpdate()
    {
        if(unscrewed==false){
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.localPosition = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        
        if(unscrewed==true)
        {
            //screw falls out after x degrees of unscrewing
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            switch (screwNum)
            {
                case 1:
                    ReferenceScript.setState(1);
                    break;
                case 2:
                    ReferenceScript.setState(2);
                    break;
                default:
                    break;
            }
        }

        // Debug.Log(transform.localEulerAngles.y);
        
        if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y < 230)
        {
            unscrewed = true;
        }
    }
}

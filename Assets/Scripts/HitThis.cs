using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitThis : MonoBehaviour
{
    public GameObject fuse;
    public GameObject spring;
    public GameObject nail;
    public int amtHit = 0;
    public MineScript ReferenceScript;
    public GameObject Mine;
    private bool wasTouching = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hammer")
        {
            //are the first 2 screws removed?
            if (ReferenceScript.mineState == 2)
            {
                Debug.Log("minestate equals 2");
                if (amtHit < 3 && wasTouching == false)
                {
                    Debug.Log("amtHit less than 3");
                    amtHit++;    
                    wasTouching = true;
                }
            }
        } 
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "hammer")
        {
            wasTouching = false;
        }
    }

    void Update()
    {
        switch (amtHit)
        {
        case 1:
            Debug.Log("first hit");
            spring.GetComponent<Rigidbody>().useGravity = true;
            break;
        case 2:
            Debug.Log("second hit");
            spring.GetComponent<Rigidbody>().useGravity = true;
            nail.GetComponent<Rigidbody>().useGravity = true;
            break;
        case 3:
            Debug.Log("third hit");
            nail.GetComponent<Rigidbody>().useGravity = true;
            spring.GetComponent<Rigidbody>().useGravity = true;
            fuse.GetComponent<Rigidbody>().useGravity = true;
            SceneLogic.ScrewTwoAction.Invoke();
            amtHit = 4;
            break;
        default:
            break;
        }
    }
}

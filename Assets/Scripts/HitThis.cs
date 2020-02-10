using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//check if rubber hammer was used to hit side of mine
//TODO: check velocity?

public class HitThis : MonoBehaviour
{
    public GameObject fuse;
    public GameObject spring;
    public GameObject nail;
    public int amtHit = 0;
    MineScript ReferenceScript;
    GameObject Mine;

    // Start is called before the first frame update
    void Start()
    {
        Mine = GameObject.FindWithTag("mineMainObject");
        ReferenceScript = Mine.GetComponent<MineScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hammer")
        {
            //are the first 2 screws removed?
            if (ReferenceScript.mineState > 2)
            {
                if (amtHit<3)
                {
                    amtHit++;          
                }
            }
        } 
    }

    void Update()
    {
        switch (amtHit)
        {
        case 1:
            Debug.Log("first hit");
            nail.GetComponent<Rigidbody>().useGravity = true;
            break;
        case 2:
            Debug.Log("second hit");
            nail.GetComponent<Rigidbody>().useGravity = true;
            spring.GetComponent<Rigidbody>().useGravity = true;
            break;
        case 3:
            Debug.Log("third hit");
            nail.GetComponent<Rigidbody>().useGravity = true;
            spring.GetComponent<Rigidbody>().useGravity = true;
            fuse.GetComponent<Rigidbody>().useGravity = true;
            break;
        default:
            break;
        }
    }
}

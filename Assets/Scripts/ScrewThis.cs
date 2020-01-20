using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add rotation of screwdriver to rotation of screw if their colliders are touching
//TODO: detect rotation past 360 degrees

public class ScrewThis : MonoBehaviour
{
    public float angleRotated = 0;
    public int rotations = 0;
    private float prevAngle = 0;
    private GameObject screwdriver;
    private Vector3 rotVec;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "screwdriver")
        {
            rotVec = new Vector3(0,0,prevAngle + screwdriver.transform.localRotation.eulerAngles.z);
            //angleRotated = screwdriver.transform.rotation.eulerAngles.z;
            //angleRotated = angleRotated + rotVec.z;
            Debug.Log("angle: " + rotVec + "rotations: " + rotations);
            
        } 
    }

    void OnTriggerExit(Collider other)
    {
        // store angle
        prevAngle = transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        //assign screwdriver to var
        screwdriver = GameObject.FindWithTag("screwdriver");

        // prevAngle = rotVec.z; 
        //rotate exact amount in degrees
        transform.localRotation = Quaternion.Euler(0,rotVec.z,0);
        //if rotation goes past 360 ie back to 0

        if (rotVec.z < prevAngle)
        {
            Debug.Log("one rotation");
            //rotations++;
        }
        //transform.Translate(0, -angleRotated*(Time.deltaTime/40000), 0);

        if (rotVec.z > 270)
        {
            //screw falls out after x degrees of unscrewing
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

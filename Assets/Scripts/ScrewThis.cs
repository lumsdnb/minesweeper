using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add rotation of screwdriver to rotation of screw if their colliders are touching

public class ScrewThis : MonoBehaviour
{

    public float speed = 10f;
    public float angleRotated = 45;
    private int rotations = 0;
    private float prevAngle = 0;
    private GameObject screwdriver;
    private Vector3 rotVec;

    // Start is called before the first frame update
    void Start()
    {
        //assign screwdriver to var
        screwdriver = GameObject.FindWithTag("screwdriver");
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "screwdriver")
        {
            rotVec = screwdriver.transform.rotation.eulerAngles;
            rotVec = new Vector3(90,0,rot.z);

            Debug.Log("angle: " + rotVec);
            
            angleRotated = rotVec.z;
        } 
    }

    void Update()
    {
        prevAngle = angleRotated; 
        //rotate exact amount in degrees
        transform.rotation = Quaternion.Euler(rotVec);
        //if rotation goes past 360 ie back to 0

        if (angleRotated < prevAngle)
        {
            rotations++;
        }
        //TODO: replace auto rotation with screwdriver input
        //transform.Rotate (0, angleRotated * Time.deltaTime, 0);
        //transform.Translate(0, -angleRotated*(Time.deltaTime/40000), 0);

        if (rot.z > 900)
        {
            //screw falls out after x degrees of unscrewing
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

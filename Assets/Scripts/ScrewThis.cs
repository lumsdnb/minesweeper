using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThis : MonoBehaviour
{

    public float speed = 10f;
    public float angleRotated = 0;
    private int rotations = 0;
    private float prevAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var prevAngle = angleRotated;
        //get rotation
        angleRotated = (rotations * 360) + Mathf.Abs(transform.localRotation.eulerAngles.y);
        //if rotation goes past 360 ie back to 0
        if (prevAngle > angleRotated)
        {
            rotations++;
        }
        //TODO: replace auto rotation with screwdriver input
        transform.Rotate (0, speed * Time.deltaTime, 0);
        transform.Translate(0, -angleRotated*(Time.deltaTime/40000), 0);

        

        if (angleRotated > 360)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

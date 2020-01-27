using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThisPhysics : MonoBehaviour
{
    public bool unscrewed = false;

    void LateUpdate()
    {
        if(unscrewed==false){
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.localPosition = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        
        // Debug.Log(transform.localEulerAngles.y);
        
        if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y < 230)
        {
            unscrewed = true;
            //screw falls out after x degrees of unscrewing
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

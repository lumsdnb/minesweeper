using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("AXIS_1") * 200;
        float rotation = Input.GetAxis("AXIS_4") * 200;
        Debug.Log(translation + ", "+ rotation);
    }
}

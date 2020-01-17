using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitchReceiver : MonoBehaviour
{
    public int toolID = 1;
    public GameObject hammer;
    public GameObject screwdriver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void pickTool(int i)
    {
        toolID=i;
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("AXIS_1");
        float axisY = Input.GetAxis("AXIS_4");
        Debug.Log(axisX);
        switch (toolID)
        {
        case 1:
            hammer.SetActive(true);
            screwdriver.SetActive(false);
            break;
        case 2:
            hammer.SetActive(false);
            screwdriver.SetActive(true);
            break;
        default:
            break;
        }
    }
}

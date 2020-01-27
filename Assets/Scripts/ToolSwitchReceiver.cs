using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitchReceiver : MonoBehaviour
{
    public int toolID = 0;
    public GameObject hammer;
    public GameObject screwdriver;

    public void pickTool(int i)
    {
        toolID=i;
    }

    // Update is called once per frame
    void Update()
    {
        switch (toolID)
        {
        case 0:
            hammer.SetActive(false);
            screwdriver.SetActive(false);
            break;
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

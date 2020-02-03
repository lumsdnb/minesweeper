using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitchReceiver : MonoBehaviour
{
    private int toolID = 0;
    public GameObject hammer;
    public GameObject screwdriver;
    public GameObject defaultHand;

    public void pickTool(int i)
    {
        toolID=i;
    }

    void Update()
    {
        switch (toolID)
        {
        case 0:
            hammer.SetActive(false);
            screwdriver.SetActive(false);
            defaultHand.SetActive(true);
            // Debug.Log("no tool");
            break;
        case 1:
            hammer.SetActive(true);
            screwdriver.SetActive(false);
            defaultHand.SetActive(true);
            // Debug.Log("tool dos");
            break;
        case 2:
            hammer.SetActive(false);
            screwdriver.SetActive(true);
            defaultHand.SetActive(true);
            // Debug.Log("tool tres");
            break;
        default:
            break;
        }
    }
}

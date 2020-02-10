using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitchReceiver : MonoBehaviour
{
    private int toolID = 0;
    public GameObject hammer;
    public GameObject screwdriver;
    public GameObject defaultHand;
    public GameObject securityGear;

    public GameObject worldScrewdriver;
    public GameObject worldHammer;

    public GameObject sceneLogic;
    

    public void pickTool(int i)
    {
        toolID=i;
    }

    void Start() 
    {
        
    }
    void Update()
    {
        int state = sceneLogic.GetComponent<SceneLogic>().gameState;
        if (Input.GetAxis("AXIS_12") == 1)
        {
            if (state > 0)
            {
                toolID = 1;
            } else toolID = 0;
            worldScrewdriver.SetActive(true);
            worldHammer.SetActive(true);
        }
        

        switch (toolID)
        {
        case 0: //no security gear
            hammer.SetActive(false);
            screwdriver.SetActive(false);
            defaultHand.SetActive(true);
            securityGear.SetActive(false);
            break;
        case 1: //security gear
            hammer.SetActive(false);
            screwdriver.SetActive(false);
            defaultHand.SetActive(false);
            securityGear.SetActive(true);
            break;
        case 2: // hammer
            hammer.SetActive(true);
            screwdriver.SetActive(false);
            defaultHand.SetActive(false);
            securityGear.SetActive(false);
            break;
        case 3: // screwdriver
            hammer.SetActive(false);
            screwdriver.SetActive(true);
            defaultHand.SetActive(false);
            securityGear.SetActive(false);
            break;
        default:
            break;
        }
    }
}

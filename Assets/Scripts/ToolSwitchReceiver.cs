using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitchReceiver : MonoBehaviour
{
    private int toolID = 1;
    public GameObject detector;
    public GameObject stick;
    public GameObject screwdriver;
    public GameObject knife;
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
        switch (toolID)
        {
        case 1:
            detector.SetActive(true);
            stick.SetActive(false);
            screwdriver.SetActive(false);
            knife.SetActive(false);
            break;
        case 2:
            detector.SetActive(false);
            stick.SetActive(true);
            screwdriver.SetActive(false);
            knife.SetActive(false);
            break;
        case 3:
            detector.SetActive(false);
            stick.SetActive(false);
            screwdriver.SetActive(true);
            knife.SetActive(false);
            break;
        case 4:
            detector.SetActive(false);
            stick.SetActive(false);
            screwdriver.SetActive(false);
            knife.SetActive(true);
            break;
        default:
            break;
        }
    }
}

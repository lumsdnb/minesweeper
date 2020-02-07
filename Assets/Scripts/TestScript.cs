using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("TestCube1"))
        {
            SceneManager.TestAction.Invoke(123);
        }
        else if(other.name.Equals("TestCube2"))
        {
            SceneManager.TestAction2.Invoke(64765);
        }
        else if (other.name.Equals("TestCube3"))
        {
            SceneManager.TestAction4.Invoke(other.gameObject);
        }

        //switch(other.name)
        //{
        //    case "TestCube1":
        //        break;
        //    case "TestCube2":
        //        break;
        //}

    }
}

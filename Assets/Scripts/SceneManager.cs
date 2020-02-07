using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    public static Action<int> TestAction { get; set; }
    public static UnityAction<int> TestAction2 { get; set; }
    public static Action TestAction3 { get; set; }
    public static Action<GameObject> TestAction4 { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TestAction += Test;
        TestAction2 += Test2;
        TestAction4 += Blubb;
    }

    private void OnDestroy()
    {
        TestAction = null;
        TestAction2 = null;
    }
    private void Blubb(GameObject go)
    {
        Debug.Log(string.Format("Blubb called {0}", go.name));

        go.transform.localScale = new Vector3(2f, 2f, 2f);

        // searching objects via GameObject.Find is usually not a good practice, because it will search the complete scene graph
        // if references are required for certain tasks, either do references via editor (the designer / non-programmer way)
        // you can search the objects once in the Start or Awake method and use this reference
        // or maybe you can search it in a smaller scope via transform.Find() -> only looks for child objects
        // -> don't do expensive stuff in update/fixedUpdate etc
        // -> bzw. wenn du ne Referenz brauchst bzw. immer wieder verwendest, dann hol sie einmal in der Start Methode (o. ä.) und verwende sie wieder
        GameObject.Find("TestCube1").transform.localScale = new Vector3(3f, 2.5f, 0.3f);
    }

    private void Test(int param)
    {
        Debug.Log(string.Format("Test Event received with param: {0}", param));
    }

    private void Test2(int param)
    {
        Debug.Log(string.Format("Test2 Event received with param: {0}", param));
    }
}

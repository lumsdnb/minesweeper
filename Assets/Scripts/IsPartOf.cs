using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPartOf : MonoBehaviour
{
    public GameObject motherObject;

    void Update()
    {
        transform.position = motherObject.transform.position;
        transform.rotation = motherObject.transform.rotation;
    }
}
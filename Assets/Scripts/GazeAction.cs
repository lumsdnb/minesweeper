﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeAction : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnGazeTriggered()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0,200,0));
    }
}

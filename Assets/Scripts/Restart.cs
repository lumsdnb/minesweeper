using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager

public class restart : MonoBehaviour
{
 
 void Update () {
     if (Input.GetKeyDown("r")) { //If you press R
         SceneManager.LoadScene("MainScene"); //Load scene called Game
     }
 }
}

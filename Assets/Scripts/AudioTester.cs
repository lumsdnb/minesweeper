using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioClip StartGame;
    public AudioClip SuitOn;
    public AudioClip WorkbenchArrived;
    public AudioClip ScrewOne;
    public AudioClip ScrewTwo;
    public AudioClip GameOver;
    public float Volume;
    AudioSource audio;


    //public bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
        //SceneLogic.StartGameAction.Invoke();
    }

    

    //void OnTriggerEnter(Collider other)
    //{
    //Debug.Log("Miau2");
    //if (other.name.Equals("AudioTriggerTentTest"))
    // {
    // Debug.Log("Miau");
    // if (!alreadyPlayed)
    //  {
    //      audio.PlayOneShot(Meow, Volume);
    //      alreadyPlayed = true;
    //   }
    //  }
    //  }
    // Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLogic : MonoBehaviour
{
    public static UnityAction StartGameAction { get; set; }
    public static UnityAction SuitOnAction { get; set; }
    public static UnityAction WorkbenchPositionAction { get; set; }
    public static UnityAction ScrewOneAction { get; set; }
    public static UnityAction ScrewTwoAction { get; set; }
    public static UnityAction GameOverAction { get; set; }



    public GameObject PlayerTrigger;

    public AudioClip StartGame;
    public AudioClip SuitOn;
    public AudioClip WorkbenchArrived;
    public AudioClip ScrewOne;
    public AudioClip ScrewTwo;
    public AudioClip GameOver;

    private AudioSource screwOneSource;
    private AudioSource screwTwoSource;


    private void Awake()
    {
        StartGameAction += StartGameFunction;
        SuitOnAction += SuitOnFunction;
        WorkbenchPositionAction += WorkbenchPositionFunction;
        ScrewOneAction += ScrewOneFunction;
        ScrewTwoAction += ScrewTwoFunction;
        GameOverAction += GameOverFunction;


        screwOneSource = SetupAudioSourceFor(PlayerTrigger, ScrewOne);
        screwTwoSource = SetupAudioSourceFor(PlayerTrigger, ScrewTwo);


    }

    // Start is called before the first frame update
    void Start()
    {



    }

    private AudioSource SetupAudioSourceFor(GameObject target, AudioClip clip)
    {
        AudioSource result = target.AddComponent<AudioSource>();
        result.clip = clip;
        result.clip = ScrewOne;
        result.playOnAwake = false;
        result.loop = false;
        result.spatialize = true;

        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartGameFunction()
    {
        Debug.Log("StartGameAction received");

        screwOneSource.Play();
    }
    private void SuitOnFunction()
    {
        Debug.Log("SuitOnAction received");
    }
    private void WorkbenchPositionFunction()
    {
        Debug.Log("WorkbenchPositionAction received");
    }
    private void ScrewOneFunction()
    {
        Debug.Log("ScrewOneAction received");
    }
    private void ScrewTwoFunction()
    {
        Debug.Log("ScrewTwoAction received");
    }
    private void GameOverFunction()
    {
        Debug.Log("GameOverAction received");
    }
}

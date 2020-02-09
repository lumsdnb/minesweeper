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

    public AudioClip StartGame; //1
    public AudioClip SuitOn; //2
    public AudioClip WorkbenchPosition; //3
    public AudioClip ScrewOne; //4 //5
    public AudioClip ScrewTwo; // 6
    public AudioClip GameOver; //explosion?
    public GameObject securityHelmet;
    public GameObject securityGear;

    private AudioSource clipToPlay;

    private int mineStateOneHappened;
    private int mineStateTwoHappened;
    private int mineStateThreeHappened;


    private void Awake()
    {
        StartGameAction += StartGameFunction;
        SuitOnAction += SuitOnFunction;
        WorkbenchPositionAction += WorkbenchPositionFunction;
        ScrewOneAction += ScrewOneFunction;
        ScrewTwoAction += ScrewTwoFunction;
        GameOverAction += GameOverFunction;

        SceneLogic.StartGameAction.Invoke();

        mineStateOneHappened = 0;
        mineStateTwoHappened = 0;
        mineStateThreeHappened = 0;


    }

    // Start is called before the first frame update
    void Start()
    {



    }

    private AudioSource SetupAudioSourceFor(GameObject target, AudioClip clip)
    {
        AudioSource result = target.AddComponent<AudioSource>();
        result.clip = clip;
        //result.clip = StartGame;
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
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, StartGame);
        clipToPlay.Play();
    }
    private void SuitOnFunction()
    {
        Debug.Log("SuitOnAction received");
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, SuitOn);
        clipToPlay.Play();
        securityHelmet.SetActive(true);
        securityGear.SetActive(false);

    }
    private void WorkbenchPositionFunction()
    {
        Debug.Log("WorkbenchPositionAction received");
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, WorkbenchPosition);
        clipToPlay.Play();
    }
    private void ScrewOneFunction()
    {
        Debug.Log("ScrewOneAction received");
        if (mineStateOneHappened.Equals(0)) { 
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, ScrewOne);
        clipToPlay.Play();
        mineStateOneHappened = 1;
        }
    }
    private void ScrewTwoFunction()
    {
        Debug.Log("ScrewTwoAction received");
        if (mineStateThreeHappened.Equals(0))
        {
            clipToPlay = SetupAudioSourceFor(PlayerTrigger, ScrewTwo);
            clipToPlay.Play();
            mineStateThreeHappened = 1;
        }
    }
    private void GameOverFunction()
    {
        Debug.Log("GameOverAction received");
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, GameOver);
        clipToPlay.Play();
    }
}

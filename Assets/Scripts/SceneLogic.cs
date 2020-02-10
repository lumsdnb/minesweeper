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
    public GameObject controllerLeft;
    public GameObject securitySuitLeft;
    public GameObject rightHandGizmo;
    public GameObject restartScreen;

    public int gameState = 0;

    private AudioSource clipToPlay;

    private int mineStateOneHappened;
    private int mineStateTwoHappened;
    private int mineStateThreeHappened;
    private int mineExploded;
    private int weNeedLouderExplosions;


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
        mineExploded = 0;


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
        if (gameState == 1)
        {
            if (PlayerTrigger.transform.position.z>=5 && PlayerTrigger.transform.position.x<=1.14)
            {
                SceneLogic.WorkbenchPositionAction.Invoke(); 
            }
        }
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
        clipToPlay.Stop();
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, SuitOn);
        clipToPlay.Play();
        securityHelmet.SetActive(true);
        securityGear.SetActive(false);
        gameState = 1;
        controllerLeft.SetActive(false);
        securitySuitLeft.SetActive(true);
        rightHandGizmo.GetComponent<ToolSwitchReceiver>().pickTool(1);
    }
    private void WorkbenchPositionFunction()
    {
        Debug.Log("WorkbenchPositionAction received");
        clipToPlay.Stop();
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, WorkbenchPosition);
        clipToPlay.Play();
        gameState = 2;
    }
    private void ScrewOneFunction()
    {
        Debug.Log("ScrewOneAction received");

        if (mineStateOneHappened.Equals(0))
        {
            if (mineExploded.Equals(0))
            {
                clipToPlay.Stop();
                clipToPlay = SetupAudioSourceFor(PlayerTrigger, ScrewOne);
                clipToPlay.Play();
                mineStateOneHappened = 1;
                gameState = 3;
            }
        }
        if (mineExploded.Equals(1))
        {
            Debug.Log("ScrewOneAction after GameOver");
        }
    }
    private void ScrewTwoFunction()
    {
        Debug.Log("ScrewTwoAction received");
        clipToPlay.Stop();
        if (mineStateThreeHappened.Equals(0))
        {
            clipToPlay = SetupAudioSourceFor(PlayerTrigger, ScrewTwo);
            clipToPlay.Play();
            mineStateThreeHappened = 1;
            gameState = 4;
        }
    }
    private void GameOverFunction()
    {
        Debug.Log("GameOverAction received");

        if (mineExploded.Equals(0))
        {
            clipToPlay.Stop();
            clipToPlay = SetupAudioSourceFor(PlayerTrigger, GameOver);
            clipToPlay.Play();
            mineExploded = 1;
            gameState = 5;
            StartCoroutine(waitForRestart());
        }
        
    }
    IEnumerator waitForRestart()
    {
        yield return new WaitForSeconds(4);
        restartScreen.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public GameObject workbench;
    public GameObject mine;
    public GameObject screwdriver;
    public GameObject hammer;
    public GameObject firstScrew;
    public GameObject secondScrew;

    public int gameState = 0;

    private AudioSource clipToPlay;

    private int mineStateOneHappened;
    //private int mineStateTwoHappened;
    private int mineStateThreeHappened;
    private int mineExploded;
    private int suitisOn;



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
        //mineStateTwoHappened = 0;
        mineStateThreeHappened = 0;
        mineExploded = 0;
        suitisOn = 0;
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
    private Outline SetUpOutline(GameObject target, Color32 color, float line)
    {
        Outline result = target.AddComponent<Outline>();
        result.OutlineMode = Outline.Mode.OutlineAll;
        result.OutlineColor = color;
        result.OutlineWidth = line;
        Debug.Log("OutlineConfigured");


        return result;
    }

    // Update is called once per frame
    void Update()
    {
        //workbench position trigger
        if (gameState == 1)
        {
            if (PlayerTrigger.transform.position.z>=5 && PlayerTrigger.transform.position.x <= 1.2)
            {
                SceneLogic.WorkbenchPositionAction.Invoke();
                Destroy(workbench.GetComponent<Outline>());
            }
        }
    }
    private void StartGameFunction()
    {
        Debug.Log("StartGameAction received");
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, StartGame);
        clipToPlay.Play();
        StartCoroutine(waitForFirstInstruction());
    }
    private void SuitOnFunction()
    {
        Debug.Log("SuitOnAction received");
        if (suitisOn.Equals(0))
        {
            Destroy(securityGear.GetComponent<Outline>());
            clipToPlay.Stop();
            clipToPlay = SetupAudioSourceFor(PlayerTrigger, SuitOn);
            clipToPlay.Play();
            securityHelmet.SetActive(true);
            securityGear.SetActive(false);
            gameState = 1;
            controllerLeft.SetActive(false);
            securitySuitLeft.SetActive(true);
            rightHandGizmo.GetComponent<ToolSwitchReceiver>().pickTool(1);
            SetUpOutline(workbench, new Color32(0, 200, 255, 255), 10f);
            suitisOn = 1;
        }
    }
    private void WorkbenchPositionFunction()
    {
        Debug.Log("WorkbenchPositionAction received");
        clipToPlay.Stop();
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, WorkbenchPosition);
        clipToPlay.Play();
        gameState = 2;
        SetUpOutline(mine, new Color32(0, 200, 255, 255), 5f);
        SetUpOutline(screwdriver, new Color32(150, 0, 255, 255), 5f);
        SetUpOutline(firstScrew, new Color32(150, 0, 255, 255), 5f);
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
                Destroy(screwdriver.GetComponent<Outline>());
                Destroy(firstScrew.GetComponent<Outline>());
                Destroy(mine.GetComponent<Outline>());
                SetUpOutline(hammer, new Color32(0, 200, 255, 255), 5f);
                SetUpOutline(secondScrew, new Color32(150, 0, 255, 255), 5f);
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
        clipToPlay = SetupAudioSourceFor(PlayerTrigger, ScrewTwo);
        clipToPlay.Play();
        mineStateThreeHappened = 1;
        gameState = 4;
        Destroy(mine.GetComponent<Outline>());
        Destroy(hammer.GetComponent<Outline>());
        Destroy(secondScrew.GetComponent<Outline>());
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
        yield return new WaitForSeconds(3);
        restartScreen.SetActive(true);
        securityHelmet.SetActive(true);
    }

    IEnumerator waitForFirstInstruction()
    {
        yield return new WaitForSeconds(53);
        SetUpOutline(securityGear, new Color32(0, 200, 255, 255), 10f);
    }

}

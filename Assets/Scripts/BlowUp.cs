using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{

    public GameObject theMine;
    public Collider boomCollider;

    public ParticleSystem ps;
    public GameObject ModelToDestroy;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "notTheRightTool")
        {
            BlowUpTheMine();
        }
    }

    public void BlowUpTheMine()
    {
        if (theMine.GetComponent<MineScript>().isArmed == true)
        {
            ps.Play();
            SceneLogic.GameOverAction.Invoke();
            boomCollider.enabled = true;
            ModelToDestroy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

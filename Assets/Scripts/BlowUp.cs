using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{

    public GameObject theMine;
    public Collider boomCollider;

    public ParticleSystem ps;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "notTheRightTool")
        {
            BlowUpTheMine();

        }
    }

    public void BlowUpTheMine()
    {
        StartCoroutine(BombCoroutine());
    }
    IEnumerator BombCoroutine()
    {
        ps.Play();
        SceneLogic.GameOverAction.Invoke();
        boomCollider.enabled = true;
        

        
        yield return new WaitForSeconds(1);

        theMine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

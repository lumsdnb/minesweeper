using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{

    public GameObject theMine;
    public Collider boomCollider;

    public ParticleSystem ps;
    public GameObject ExplosionPrefab;


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
            StartCoroutine(BombCoroutine());
            // GameObject a = Instantiate(ExplosionPrefab) as GameObject;

        }
    }
    IEnumerator BombCoroutine()
    {
        ps.Play();
        SceneLogic.GameOverAction.Invoke();
        boomCollider.enabled = true;

        yield return new WaitForSeconds(1F);

        theMine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

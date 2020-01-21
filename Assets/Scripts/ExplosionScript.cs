using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public GameObject Explosion;
    public bool alreadyExploded = false;
    GameObject Mine;
    MineScript ReferenceScript;
    // Start is called before the first frame update
    void Start()
    {
        Mine = GameObject.FindWithTag("mineMainObject");
        ReferenceScript = Mine.GetComponent<MineScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (ReferenceScript.mineState < 4)
        {
            Debug.Log("Mine is armed");
            // mineState = 4
            if (other.tag.Equals("mine"))
                {
                    if (!alreadyExploded)
                    {
                        Debug.Log("Explosion!");
                        Instantiate(Explosion, new Vector3(-0.2f, 3.8f, 3.1f), Quaternion.identity, Explosion.transform.parent);
                        Explosion.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                        alreadyExploded = true;
                    }
                    Debug.Log("Already Exploded!");
                }
        }
        else
        {
            Debug.Log("Mine is not armed!");
        }
        }
    }

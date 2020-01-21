using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.tag.Equals("mine"))
        {
            Debug.Log("Explosion");
            Instantiate(Explosion, new Vector3(0, 4, 3), Quaternion.identity);

        }
    }
}

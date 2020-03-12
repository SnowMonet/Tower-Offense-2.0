using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    public int cpLives;

    public GameObject CPholder;
    public Transform allyWatchtower;

    // Start is called before the first frame update
    void Start()
    {
        cpLives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(cpLives <= 0)
        {
            destroyFunction();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ally")
        {
            Debug.Log("Ow");
            cpLives -= 1;
            Destroy(other.gameObject);
        }

    }

    void destroyFunction()
    {

        CPholder.GetComponent<TerritoryConversion>().calculateArray();
        Instantiate(allyWatchtower, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour
{

    public int cpLives;

    public GameObject CPholder;
    public Transform allyWatchtower;

    public Text CPHealth;

    // Start is called before the first frame update
    void Start()
    {
        cpLives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        CPHealth.text = cpLives.ToString();

        if(cpLives <= 0)
        {
            destroyFunction();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ally")
        {
            //Debug.Log("Ow");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnits : MonoBehaviour
{
    public Transform allySpawnPoint;

    public Transform allyLeftPrefab;
    public Transform allyCenterPrefab;
    public Transform allyRightPrefab;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            if(!buildManager.CanAlly)
            {
                Debug.Log("Not Enough Essence!");
                return;
            }
            if(buildManager.CanAlly)
            {
                Instantiate(allyLeftPrefab, allySpawnPoint.position, allySpawnPoint.rotation);
                buildManager.essenceResource -= buildManager.allyCost;
            }
        }

        if (Input.GetKeyDown("f"))
        {
            if (!buildManager.CanAlly)
            {
                Debug.Log("Not Enough Essence!");
                return;
            }
            if (buildManager.CanAlly)
            {
                Instantiate(allyCenterPrefab, allySpawnPoint.position, allySpawnPoint.rotation);
                buildManager.essenceResource -= buildManager.allyCost;
            }
        }

        if (Input.GetKeyDown("v"))
        {
            if (!buildManager.CanAlly)
            {
                Debug.Log("Not Enough Essence!");
                return;
            }
            if (buildManager.CanAlly)
            {
                Instantiate(allyRightPrefab, allySpawnPoint.position, allySpawnPoint.rotation);
                buildManager.essenceResource -= buildManager.allyCost;
            }
        }
    }
}

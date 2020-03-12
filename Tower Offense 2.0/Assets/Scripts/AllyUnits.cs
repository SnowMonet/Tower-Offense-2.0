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
            spawnLeftAlly();
        }

        if (Input.GetKeyDown("f"))
        {
            spawnMiddleAlly();
        }

        if (Input.GetKeyDown("v"))
        {
            spawnRightAlly();
        }
    }

    public void spawnLeftAlly()
    {

        if (!buildManager.CanAlly)
        {
            Debug.Log("Not Enough Essence!");
            return;
        }
        if (buildManager.CanAlly)
        {
            Instantiate(allyLeftPrefab, allySpawnPoint.position, allySpawnPoint.rotation);
            buildManager.essenceResource -= buildManager.allyCost;
        }

    }

    public void spawnMiddleAlly()
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

    public void spawnRightAlly()
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

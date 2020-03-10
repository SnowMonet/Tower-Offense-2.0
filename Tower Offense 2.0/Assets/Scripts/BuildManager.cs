using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager");
            return;
        }

        instance = this;
    }

    public GameObject waterTowerPrefab;

    void Start()
    {
        towerToBuild = waterTowerPrefab;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}

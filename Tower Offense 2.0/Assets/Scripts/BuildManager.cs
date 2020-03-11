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
    public GameObject windTowerPrefab;
    public GameObject earthTowerPrefab;

    void Start()
    {
        towerToBuild = waterTowerPrefab;
    }

    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            Debug.Log("Water Tower Selected");
            towerToBuild = waterTowerPrefab;
        }

        if (Input.GetKeyDown("x"))
        {
            Debug.Log("Wind Tower Selected");
            towerToBuild = windTowerPrefab;
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log("Earth Tower Selected");
            towerToBuild = earthTowerPrefab;
        }
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}

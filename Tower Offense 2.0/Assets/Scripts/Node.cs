using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;

    public Vector3 towerOffset;
    public bool useOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if(buildManager.GetTowerToBuild() == null)
        {
            Debug.Log("No Tower Selected!");
            return;
        }

        if(tower != null)
        {
            Debug.Log("Space Occupied");
            return;
        }

        if(!buildManager.CanBuild)
        {
            Debug.Log("Not Enough Energy!");
            return;
        }

        GameObject towerToBuild = buildManager.GetTowerToBuild();
        if(!useOffset)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
            buildManager.energyResource -= 5f;
        }
        else if(useOffset)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + towerOffset, transform.rotation);
            buildManager.energyResource -= 5f;
        }
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

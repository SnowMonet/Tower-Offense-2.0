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

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(tower != null)
        {
            Debug.Log("Space Occupied");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        if(!useOffset)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
        }
        else if(useOffset)
        {
            tower = (GameObject)Instantiate(towerToBuild, transform.position + towerOffset, transform.rotation);
        }
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

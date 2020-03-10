using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryConversion : MonoBehaviour
{

    public GameObject enemyTerritory;
    public GameObject allyTerritory;

    public GameObject[] CParray;

    public bool territoryConverted;

    // Start is called before the first frame update
    void Start()
    {
        territoryConverted = false;
        calculateArray();
    }

    // Update is called once per frame
    void Update()
    {
        if(CParray.Length <= 1 && territoryConverted == false)
        {
            convertTerritory();
        }
    }

    void convertTerritory()
    {

        enemyTerritory.SetActive(false);
        allyTerritory.SetActive(true);

        territoryConverted = true;
    }

    public void calculateArray()
    {
        CParray = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            CParray[i] = transform.GetChild(i).gameObject;
        }
    }

}

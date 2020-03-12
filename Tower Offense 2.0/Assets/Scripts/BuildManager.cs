using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject[] towerLogos = new GameObject[3];
    public GameObject[] cameraViews = new GameObject[5];
    public GameObject towerPanel;
    public GameObject cameraPanel;
    public GameObject selectedTowerPanel;

    public Text selectedTowerText;

    public int towerPanelActiveIndex;
    public int cameraPanelActiveIndex;
    public int selectedTowerPanelActiveIndex;
    public int cameraViewIndex;

    public Image waterTowerOutline;
    public Image windTowerOutline;
    public Image earthTowerOutline;

    public float energyResource = 0f;
    public int roundedEnergy;

    public float essenceResource = 0f;
    public int roundedEssence;
    public float allyCost = 3f;

    public Text energyText;
    public Text essenceText;

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

    public bool CanBuild;
    public bool CanAlly;

    void Start()
    {
        //towerToBuild = waterTowerPrefab;
        cameraViewIndex = 0;
        towerPanelActiveIndex = 0;
        cameraPanelActiveIndex = 0;
        selectedTowerPanelActiveIndex = 0;
        selectedTowerText.text = "Water Tower Selected";
    }

    void Update()
    {
        if(energyResource <= 20)
        {
            energyResource += 1f * Time.deltaTime;
        }

        if(energyResource >= 5)
        {
            CanBuild = true;
        }
        else if(energyResource < 5)
        {
            CanBuild = false;
        }

        if(essenceResource >= allyCost)
        {
            CanAlly = true;
        }
        else if(essenceResource < allyCost)
        {
            CanAlly = false;
        }

        roundedEnergy = (int)energyResource;
        energyText.text = roundedEnergy.ToString();

        roundedEssence = (int)essenceResource;
        essenceText.text = roundedEssence.ToString();


        if(Input.GetKeyDown("z"))
        {
            waterTower();
        }

        if (Input.GetKeyDown("x"))
        {
            windTower();
        }

        if (Input.GetKeyDown("c"))
        {
            earthTower();
        }
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void waterTower()
    {
        Debug.Log("Water Tower Selected");
        selectedTowerText.text = "Water Tower Selected";
        towerLogos[0].SetActive(true);
        towerLogos[1].SetActive(false);
        towerLogos[2].SetActive(false);
        towerToBuild = waterTowerPrefab;
        waterTowerOutline.enabled = true;
        windTowerOutline.enabled = false;
        earthTowerOutline.enabled = false;
    }

    public void windTower()
    {
        Debug.Log("Wind Tower Selected");
        selectedTowerText.text = "Wind Tower Selected";
        towerLogos[0].SetActive(false);
        towerLogos[1].SetActive(true);
        towerLogos[2].SetActive(false);
        towerToBuild = windTowerPrefab;
        waterTowerOutline.enabled = false;
        windTowerOutline.enabled = true;
        earthTowerOutline.enabled = false;
    }

    public void earthTower()
    {
        Debug.Log("Earth Tower Selected");
        selectedTowerText.text = "Earth Tower Selected";
        towerLogos[0].SetActive(false);
        towerLogos[1].SetActive(false);
        towerLogos[2].SetActive(true);
        towerToBuild = earthTowerPrefab;
        waterTowerOutline.enabled = false;
        windTowerOutline.enabled = false;
        earthTowerOutline.enabled = true;
    }

    public void closeTowerPanel()
    {
        towerPanelActiveIndex += 1;

        if(towerPanelActiveIndex >= 2)
        {
            towerPanelActiveIndex = 0;
        }

        if(towerPanelActiveIndex == 0)
        {
            towerPanel.SetActive(true);
        }

        if (towerPanelActiveIndex == 1)
        {
            towerPanel.SetActive(false);
        }
    }

    public void closeCameraPanel()
    {
        cameraPanelActiveIndex += 1;

        if (cameraPanelActiveIndex >= 2)
        {
            cameraPanelActiveIndex = 0;
        }

        if (cameraPanelActiveIndex == 0)
        {
            cameraPanel.SetActive(true);
        }

        if (cameraPanelActiveIndex == 1)
        {
            cameraPanel.SetActive(false);
        }
    }

    public void closeSelectedTowerPanel()
    {
        selectedTowerPanelActiveIndex += 1;

        if (selectedTowerPanelActiveIndex >= 2)
        {
            selectedTowerPanelActiveIndex = 0;
        }

        if (selectedTowerPanelActiveIndex == 0)
        {
            selectedTowerPanel.SetActive(true);
        }

        if (selectedTowerPanelActiveIndex == 1)
        {
            selectedTowerPanel.SetActive(false);
        }
    }

    public void changeCamera()
    {

        cameraViewIndex += 1;

        if (cameraViewIndex >= 5)
        {
            cameraViewIndex = 0;
        }

        if (cameraViewIndex == 0)
        {
            cameraViews[0].SetActive(true);
            cameraViews[1].SetActive(false);
            cameraViews[2].SetActive(false);
            cameraViews[3].SetActive(false);
            cameraViews[4].SetActive(false);
        }

        if (cameraViewIndex == 1)
        {
            cameraViews[0].SetActive(false);
            cameraViews[1].SetActive(true);
            cameraViews[2].SetActive(false);
            cameraViews[3].SetActive(false);
            cameraViews[4].SetActive(false);
        }

        if (cameraViewIndex == 2)
        {
            cameraViews[0].SetActive(false);
            cameraViews[1].SetActive(false);
            cameraViews[2].SetActive(true);
            cameraViews[3].SetActive(false);
            cameraViews[4].SetActive(false);
        }

        if (cameraViewIndex == 3)
        {
            cameraViews[0].SetActive(false);
            cameraViews[1].SetActive(false);
            cameraViews[2].SetActive(false);
            cameraViews[3].SetActive(true);
            cameraViews[4].SetActive(false);
        }

        if (cameraViewIndex == 4)
        {
            cameraViews[0].SetActive(false);
            cameraViews[1].SetActive(false);
            cameraViews[2].SetActive(false);
            cameraViews[3].SetActive(false);
            cameraViews[4].SetActive(true);
        }

    }

}

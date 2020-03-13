using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    public Sprite eyeOpen;
    public Sprite eyeClosed;

    public Button towerPanelButton;
    public Button cameraPanelButton;
    public Button allyUnitPanelButton;

    // Start is called before the first frame update
    void Start()
    {
        //towerPanelButton.transform.position = new Vector3(685f, 435f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTowerImage()
    {
        if (towerPanelButton.image.sprite == eyeOpen)
        {
            towerPanelButton.image.sprite = eyeClosed;
            //towerPanelButton.transform.position = new Vector3(785f, 435f, 0f);
            
            
        }
        else
        {
            towerPanelButton.image.sprite = eyeOpen;
            //towerPanelButton.transform.position = new Vector3(685f, 435f, 0f);
        }
    }

    public void ChangeCameraImage()
    {
        if (cameraPanelButton.image.sprite == eyeOpen)
        {
            cameraPanelButton.image.sprite = eyeClosed;
        }
        else
        {
            cameraPanelButton.image.sprite = eyeOpen;
        }
    }

    public void ChangeUnitImage()
    {
        if (allyUnitPanelButton.image.sprite == eyeOpen)
        {
            allyUnitPanelButton.image.sprite = eyeClosed;
        }
        else
        {
            allyUnitPanelButton.image.sprite = eyeOpen;
        }
    }
}

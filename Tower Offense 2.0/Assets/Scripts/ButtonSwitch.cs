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

    // Start is called before the first frame update
    void Start()
    {
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
        }
        else
        {
            towerPanelButton.image.sprite = eyeOpen;
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
}

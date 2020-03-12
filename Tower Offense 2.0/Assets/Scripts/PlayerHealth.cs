using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealthValue;
    public int playerStartHealth = 5;

    public Text playerHealthText;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthValue = playerStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = playerHealthValue.ToString();
    }
}

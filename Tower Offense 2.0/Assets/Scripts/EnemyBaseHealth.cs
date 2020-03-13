using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseHealth : MonoBehaviour
{
    public static int enemyBaseHealthValue;
    public int enemyBaseStartHealth = 10;

    public Text enemyBaseHealthText;

    // Start is called before the first frame update
    void Start()
    {
        enemyBaseHealthValue = enemyBaseStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyBaseHealthText.text = enemyBaseHealthValue.ToString();
    }
}

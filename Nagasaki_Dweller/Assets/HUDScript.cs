using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TMP_Text healthOutText;
    public TMP_Text levelOutText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        healthOutText.text = "Health: " + Character.Instance.currentHP.ToString() + "/" + Character.Instance.maxHP;
        levelOutText.text = "Level: " + Character.Instance.currentLevel.ToString();
        
    }
}

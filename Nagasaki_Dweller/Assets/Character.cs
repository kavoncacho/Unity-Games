using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    //variables
    public int currentXP = 0;
    public int currentHP = 150;
    public int maxHP = 150;
    public int currentLevel = 1;
    public string currentWeapon = "";
    public bool weaponEquipped = false;
    public int damageOutput = 10;

    void Update()
    {
        levelUpCheck();
    }
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addXP(int currXP)
    {
        currentXP = currentXP + currXP;
        Debug.Log("Current XP is now " + currentXP);
        //levelUpCheck();
    }

    public void levelUpCheck()
    {
        if (currentXP >= currentLevel * 300)
        {
            //Debug.Log("the if statement was reached");
            currentLevel = currentLevel + 1;
            maxHP = maxHP + 50;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            playerDeath();
        }
    }

    public void playerDeath()
    {
        Debug.Log("You died...");
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        SceneManager.LoadScene("Quit");
    }
}

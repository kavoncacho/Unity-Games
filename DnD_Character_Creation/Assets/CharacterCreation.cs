using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    public static CharacterCreation Instance { get; private set; }

    //character variables
    public static bool charCreated = false;
    public string charName;
    public int ability_Strength;
    public int ability_Dexterity;
    public int ability_Constitution;
    public int ability_Intelligence;
    public int ability_Wisdom;
    public int ability_Charisma;
    public string race;
    public string charClass;
    public string alignment;
    public int currentXP;
    public int maxXP;
    public int currentHP;
    public int maxHP;
    public int armorClass;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpHeight;
    List<string> itemList = new List<string>();
    public string playerJson;

    //misc variables
    private bool abilityRolled = false;
    private bool xphpRolled = false;
    //private bool updatedJSON = false;
    
    //text
    public TMP_Text strengthOutText;
    public TMP_Text dexterityOutText;
    public TMP_Text constitutionOutText;
    public TMP_Text intelligenceOutText;
    public TMP_Text wisdomOutText;
    public TMP_Text charismaOutText;
    public TMP_Text currentXPOutText;
    public TMP_Text currentHPOutText;
    public TMP_Text maxXPOutText;
    public TMP_Text maxHPOutText;
    public TMP_Text armorClassOutText;
    public TMP_Text walkingSpeedOutText;
    public TMP_Text runningSpeedOutText;
    public TMP_Text jumpHeightOutText;
    public TMP_Text jsonOutText;


    //checkpoints. used for determining whether character is done
    public bool nameCheckpoint = false;
    public bool raceCheckpoint = false;
    public bool classCheckpoint = false;
    public bool alignmentCheckpoint = false;
    public bool abilityCheckpoint = false;
    public bool speedsCheckpoint = false;
    public bool xpHPArmorCheckpoint = false;
    

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

    public void Start()
    {
        playerJson = JsonUtility.ToJson(Instance);
        jsonOutText.text = playerJson;
    }
    
    public void updateJson()
    {
        playerJson = JsonUtility.ToJson(Instance);
        jsonOutText.text = playerJson;
    }

    public void setName(string charname)
    {
        Instance.charName = charname;
        if (charName == "")
        {
            nameCheckpoint = false;
        }
        else
        {
            Debug.Log("Your name has been set to " + charName);
            nameCheckpoint = true;
        }
    }

    public void addXP(int currXP)
    {
        currentXP = currentXP + currXP;
        currentXPOutText.text = "Current XP = " + currentXP.ToString();
        Debug.Log("Current XP is now " + currentXP);
    }

    public void changeHP(int hpChange)
    {
        currentHP = currentHP + hpChange;
        currentHPOutText.text = "Current HP = " + currentHP.ToString();
        Debug.Log("Current HP is now " + currentHP);
    }

    public void changeArmorClass(int newArmor)
    {
        armorClass = armorClass + newArmor;
        armorClassOutText.text = "Armor Class = " + armorClass.ToString();
        Debug.Log("Armor Class is now " + armorClass);
    }

    public void rollSpeeds()
    {
        walkingSpeed = Random.Range(20.00f, 50.00f);
        walkingSpeedOutText.text = "Walking Speed = " + walkingSpeed.ToString();
        Debug.Log("Walking Speed  = " + walkingSpeed.ToString());
        runningSpeed = Random.Range(50.00f, 100.00f);
        runningSpeedOutText.text = "Running Speed = " + runningSpeed.ToString();
        Debug.Log("Running Speed = " + runningSpeed.ToString());
        jumpHeight = Random.Range(2.00f, 10.00f);
        jumpHeightOutText.text = "Jump Height = " + jumpHeight.ToString();
        Debug.Log("Jump Height = " + jumpHeight.ToString());
        speedsCheckpoint = true;
    }

    public void getMaxXPHP()
    {
        if (xphpRolled == false)
        {
            maxXP = Random.Range(10000, 100000);
            maxHP = Random.Range(1000, 9999);
            maxXPOutText.text = "Max XP = " + maxXP.ToString();
            Debug.Log("Max XP is now " + maxXP.ToString());
            maxHPOutText.text = "Max HP = " + maxHP.ToString();
            Debug.Log("Max XP is now " + maxXP.ToString());
            currentXP = 0;
            currentHP = 100;
            armorClass = 35;
            xphpRolled = true;
            xpHPArmorCheckpoint = true;
        }
        else
        {
            Debug.Log("You already rolled your maximum XP and HP");
        }
    }
    
    public void rollAbilities()
    {
        if (abilityRolled == false)
        {
            ability_Strength = rollAbilitiesHelper(ability_Strength);
            strengthOutText.text = "Your strength is " + ability_Strength.ToString();
            Debug.Log("Your strength is " + ability_Strength.ToString());
            ability_Dexterity = rollAbilitiesHelper(ability_Dexterity);
            dexterityOutText.text = "Your dexterity is " + ability_Dexterity.ToString();
            Debug.Log("Your dexterity is " + ability_Dexterity.ToString());
            ability_Constitution = rollAbilitiesHelper(ability_Constitution);
            constitutionOutText.text = "Your constitution is " + ability_Constitution.ToString();
            Debug.Log("Your constitution is " + ability_Constitution.ToString());
            ability_Intelligence = rollAbilitiesHelper(ability_Intelligence);
            intelligenceOutText.text = "Your intelligence is " + ability_Intelligence.ToString();
            Debug.Log("Your intelligence is " + ability_Intelligence.ToString());
            ability_Wisdom = rollAbilitiesHelper(ability_Wisdom);
            wisdomOutText.text = "Your wisdom is " + ability_Wisdom.ToString();
            Debug.Log("Your wisdom is " + ability_Wisdom.ToString());
            ability_Charisma = rollAbilitiesHelper(ability_Charisma);
            charismaOutText.text = "Your charisma is " + ability_Charisma.ToString();
            Debug.Log("Your charisma is " + ability_Charisma.ToString());
            abilityRolled = true;
            abilityCheckpoint = true;
        }
        else
        {
            Debug.Log("You already rolled your abilities");
        }
    }
    
    public int rollAbilitiesHelper(int ability)
    {
        int abilityTotal = 0;
        int first = 0;
        int second = 0;
        int third = 0;
        int[] randIntArray = new int[7];
        
        for (int j = 0; j< 7; ++j) 
        {
            randIntArray[j] = Random.Range(1, 5);
        }
        

        for (int i = 0; i < randIntArray.Length; ++i)
        {
            if (randIntArray[i] > first)
            {
                third = second;
                second = first;
                first = randIntArray[i];
            }
            else if (randIntArray[i] > second)
            {
                third = second;
                second = randIntArray[i];
            }
            else if (randIntArray[i] > third)
            {
                third = randIntArray[i];
            }
        }   
        
        return abilityTotal + first + second + third + 2;
    }

    public void setRace(int charrace)
    {
        if (charrace == 1)
        {
            race = "Dragonborn";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 2)
        {
            race = "Dwarf";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 3)
        {
            race = "Elf";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 4)
        {
            race = "Gnome";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 5)
        {
            race = "Half-Elf";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 6)
        {
            race = "Half-Orc";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 7)
        {
            race = "Halfling";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 8)
        {
            race = "Human";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else if (charrace == 9)
        {
            race = "Tiefling";
            Debug.Log("Your race has been set to " + race);
            raceCheckpoint = true;
        }
        else
        {
            Debug.Log("Please choose a race");
            raceCheckpoint = false;
        }
        
    }

    public void setClass(int charclass)
    {
        if (charclass == 1)
        {
            charClass = "Barbarian";
            Debug.Log("Your class has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 2)
        {
            charClass = "Bard";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 3)
        {
            charClass = "Cleric";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 4)
        {
            charClass = "Druid";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 5)
        {
            charClass = "Fighter";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 6)
        {
            charClass = "Monk";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 7)
        {
            charClass = "Paladin";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 8)
        {
            charClass = "Ranger";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 9)
        {
            charClass = "Rogue";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 10)
        {
            charClass = "Sorcerer";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 11)
        {
            charClass = "Warlock";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else if (charclass == 12)
        {
            charClass = "Wizard";
            Debug.Log("Your race has been set to " + charClass);
            classCheckpoint = true;
        }
        else
        {
            Debug.Log("Please choose a class");
            classCheckpoint = false;
        }

    }

    public void setAlignment(int charalignment)
    {
        if (charalignment == 1)
        {
            alignment = "Lawful Good";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 2)
        {
            alignment = "Neutral Good";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 3)
        {
            alignment = "Chaotic Good";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 4)
        {
            alignment = "Lawful Neutral";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 5)
        {
            alignment = "True Neutral";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 6)
        {
            alignment = "Chaotic Neutral";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 7)
        {
            alignment = "Lawful Evil";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 8)
        {
            alignment = "Neutral Evil";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else if (charalignment == 9)
        {
            alignment = "Chaotic Evil";
            Debug.Log("Your alignment has been set to " + alignment);
            alignmentCheckpoint = true;
        }
        else
        {
            Debug.Log("Please choose an alignment");
            alignmentCheckpoint = false;
        }

    }

    public void checkProgress()
    {
        if(nameCheckpoint && raceCheckpoint && classCheckpoint && alignmentCheckpoint
             && abilityCheckpoint && speedsCheckpoint && xpHPArmorCheckpoint == true)
        {
            Debug.Log("Character finished!");
            charCreated = true;
            SceneManager.LoadScene("MainMenu");
            //return charCreated;
        }
        else
        {
            Debug.Log("Please finish making your character");
            charCreated = false;
            //return charCreated;
        }
    }
}

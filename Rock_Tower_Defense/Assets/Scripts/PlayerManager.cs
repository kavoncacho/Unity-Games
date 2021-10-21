using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public class Player
    {
        public int healthPotion;
        public int coins;
        public string highScore;

        public string defaultAmmoName = "Rock";
        public int defaultAmmo = 10;
        public string midAmmoName = "Metal";
        public int midAmmo = 0;
        public int midAmmoBought;
        
    }

    public Player player = new Player();

    public static PlayerManager _instance;

    //public Dictionary<string, int> weaponsDict = new Dictionary<string, int>();

    private void Start()
    {
        /*weaponsDict.Add(player.defaultAmmoName, player.defaultAmmo);
        weaponsDict.Add(player.midAmmoName, player.midAmmo);*/
    }


    private void Awake()
    {
        if (_instance == null)
        {

            DontDestroyOnLoad(gameObject);
            _instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

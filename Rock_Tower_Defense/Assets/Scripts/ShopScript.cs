using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{

    public Button buyHP, buyAmmo;
    public Button toGame;
    public PlayerManager playerManager;

    public TMP_Text healthOut, ammo1Out, ammo2Out, coinOut;
    

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        buyHP = GameObject.Find("hpButton").GetComponent<Button>();
        //buyAmmo = GameObject.Find("ammo1Button").GetComponent<Button>();
        toGame = GameObject.Find("Back").GetComponent<Button>();
        healthOut = GameObject.Find("healthOut").GetComponent<TMP_Text>();
        //ammo1Out = GameObject.Find("ammoOneOut").GetComponent<TMP_Text>();
        //ammo2Out = GameObject.Find("ammoTwoOut").GetComponent<TMP_Text>();
        coinOut = GameObject.Find("CoinOut").GetComponent<TMP_Text>();

        buyHP.onClick.AddListener(buyHealthPot);
        //buyAmmo.onClick.AddListener(buyAmmoType);
        toGame.onClick.AddListener(() => moveScene(0));
    }

    void Update()
    {
        healthOut.text = playerManager.player.healthPotion.ToString();
        //ammo1Out.text = playerManager.player.midAmmoBought.ToString();
        coinOut.text = playerManager.player.coins.ToString();
    }

    void moveScene (int scene)
    {
        SceneManager.LoadScene(scene);
    }

    void buyHealthPot()
    {
        if (playerManager.player.coins >= 5)
        {
            playerManager.player.healthPotion++;
            playerManager.player.coins -= 5;
        }
        
    }

    void buyAmmoType()
    {
        if (playerManager.player.coins >= 10)
        {
            playerManager.player.coins -= 10;
            playerManager.player.midAmmo += 10;
            playerManager.player.midAmmoBought++;
           
        }
       
    }


}

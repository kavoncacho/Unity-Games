using UnityEngine;
using TMPro;
public class HUDController : MonoBehaviour
{
    
    public TMP_Text health, ammoType, currency, ammo;
    public WallScript wall;
    public PlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        wall = GameObject.Find("tower").GetComponent<WallScript>();
        health = GameObject.Find("HealthNum").GetComponent<TMP_Text>();
        ammoType = GameObject.Find("AmmoType").GetComponent<TMP_Text>();
        currency = GameObject.Find("CoinNum").GetComponent<TMP_Text>();
        ammo = GameObject.Find("AmmoLeft").GetComponent<TMP_Text>();
        
    }

    void Update()
    {
        health.text = wall.currentWallHealth.ToString();
        currency.text = playerManager.player.coins.ToString();

    }
}

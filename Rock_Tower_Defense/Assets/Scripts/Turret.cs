using UnityEngine;
using UnityEngine.Audio;

public class Turret : MonoBehaviour
{

    public PlayerManager playerManager;
    public WallScript wall;

    //comment for new merge 
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    

    public GameObject rockPrefab;
    public Transform firePoint;

    public Camera fpsCam;
    private AudioSource cannonShot;

    

    void Shoot()
    {   
        cannonShot.Play();
        GameObject bulletobj = (GameObject)Instantiate(rockPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletobj, 10f);

       
    }


    void Start()
    {
        wall = GameObject.Find("tower").GetComponent<WallScript>();
        cannonShot = GetComponent<AudioSource>();
       playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        if (Input.GetMouseButtonDown(1) && playerManager.player.healthPotion > 0)
        {
            wall.currentWallHealth += 25;
            playerManager.player.healthPotion--;
        }





    }
}

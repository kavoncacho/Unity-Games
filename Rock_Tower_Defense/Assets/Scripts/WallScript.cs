using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    public StopWatch watch;
    public static WallScript wallInstance { get; private set; }

    public int currentWallHealth;
    public int maxWallHealth;

    public Rigidbody wallRB;
    public Collider wallCollider;
    //public Animator wallAnimator;    <---- ??? maybe take hit animations
    public LayerMask enemyLayer;

    void Start()
    {
       
    }

    void Update()
    {
        isDead();
    }

    public void TakeDamage(int damage)
    {
        currentWallHealth -= damage;
        Debug.Log(currentWallHealth);//play wall damage sound
        //take hit animation ??

        if (currentWallHealth <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        Debug.Log("The wall has been destroyed");
        //play sound ???
        GetComponent<Collider>().enabled = false;
        //this.enabled = false;
    }

    void isDead()
    {
        if (currentWallHealth <= 0)
        {
            watch.isRunning = false;
            SceneManager.LoadScene("ShopScene");
        }
    }

}

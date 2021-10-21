using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyScript : MonoBehaviour
{
    public PlayerManager playerManager;
    public static EnemyScript enemyInstance { get; private set; }

    public float timer;


    public float speed = 0.3f; 
    public int currentEnemyHealth;
    public int maxEnemyHealth;
    public int enemyDamageOutput;

    public float enemyAttackRate;
    public float enemyAttackTiming;
    public float enemyAttackRange;

    public Rigidbody enemyRB;
    public Collider enemyCollider;
    public Animator enemyAnimator;
    public LayerMask bulletLayer;
    public LayerMask wallLayer;
    public Transform enemyAttackPoint;
    private GameObject WallTarget;
    private AudioSource deathCry;
    void Start()
    {
        deathCry = GetComponent<AudioSource>();
        enemyAnimator = GetComponent<Animator>();
        WallTarget = GameObject.Find("Target");
        enemyAttackPoint = transform;
        timer = Time.deltaTime;

        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 15f && timer <= 15.1f)
        {
            currentEnemyHealth = 120;
            //transform.localScale = new Vector3(7,7); 
        }
        else if (timer >= 30f && timer <= 30.1f)
        {
            currentEnemyHealth = 140;

        }
        else if (timer >= 45f && timer <= 45.1f)
        {
            currentEnemyHealth = 150;
            

        }
        else if (timer >= 60f && timer <= 60.1f)
        {
            currentEnemyHealth = 250;
            

        }
        
        transform.LookAt(WallTarget.transform);
        GameObject[] baddies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject baddie in baddies)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        /*foreach(GameObject baddie in baddies)
        {
           baddie.transform.position = Vector3.MoveTowards(baddie.transform.position, WallTarget.transform.position, 1.0f); 
        }
        */
    }
    
    void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "tower")
        {
            enemyAttack();
            Debug.Log("Took Damage");
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyAnimator.SetBool("HitByBullet", true);
        //enemyAnimator.SetTrigger("TakeHit");
        //play rock sound
        if (currentEnemyHealth == 0)
        {
            Die();
        }
        enemyAnimator.SetBool("HitByBullet", false);
    }


    public void enemyAttack()
    {
        Collider[] hitWall = Physics.OverlapSphere(enemyAttackPoint.position, enemyAttackRange, wallLayer);
        foreach (Collider wall in hitWall)
        {
            Debug.Log("The wall got hit");
            wall.GetComponent<WallScript>().TakeDamage(enemyDamageOutput);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }

    void Die()
    {
        deathCry.Play();
        Debug.Log("Enemy has been killed");
        //play grunt death
        //enemyAnimator.SetBool("isDead", true);
        enemyAnimator.SetTrigger("Die");
        Destroy(gameObject,1f);
        //this.enabled = false;
        playerManager.player.coins += 5;
    }
}

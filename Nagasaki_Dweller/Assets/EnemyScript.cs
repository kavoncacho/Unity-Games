using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{

    public static EnemyScript enemyInstance { get; private set; }

    public int currentEnemyHealth;
    public int maxEnemyHealth = 150;
    public int xpGain = 150;
    public int enemyDamageOutput = 10;
    
    public Transform ceilingCheck;
    public Transform groundCheck;
    public Transform leftCheck;
    public Transform rightCheck;
    public Transform enemyAttackPoint;
    public float enemyAttackRange = 0.5f;
    public float enemyAttackRate = 30f;
    public float enemyAttackTiming = 0f;
    public float attackFloat = 0f;
    public LayerMask BorderObjects;
    public LayerMask groundObjects;

    public Rigidbody2D enemyRB;
    public Collider2D attackEntryPointCollider;
    public Animator enemyAnimator; //skeleton
    public LayerMask playerLayer;
    public LayerMask enemyAttackEntryPoint;

    // Start is called before the first frame update
    void Start()
    {
        //currentEnemyHealth = maxEnemyHealth;
    }
    /*
    public void Awake()
    {
        if (enemyInstance == null)
        {
            enemyInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
    // Update is called once per frame
    // && attackEntryPointCollider.IsTouchingLayers(11)
    void Update()
    {
        if ((Time.time >= enemyAttackTiming))
        {
            enemyAttack();
            enemyAnimator.SetTrigger("Attack");
            enemyAttackTiming = Time.time + attackFloat / enemyAttackRate;
        }
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyAnimator.SetTrigger("TakeHit");

        if (currentEnemyHealth <= 0)
        {
            Die();
        }
    }

    public void enemyAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("You got hit");
            player.GetComponent<Character>().TakeDamage(enemyDamageOutput);
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
        Debug.Log("Enemy died...");
        Character.Instance.currentXP += xpGain;
        enemyAnimator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

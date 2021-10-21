using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript2 : MonoBehaviour
{

    public static EnemyScript2 enemyInstance { get; private set; }

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
    public Animator enemyAnimator2; //goblin
    public LayerMask playerLayer;
    public LayerMask enemyAttackEntryPoint;

    // Start is called before the first frame update
    void Start()
    {
        //currentEnemyHealth = maxEnemyHealth;
    }

    // Update is called once per frame
    // && attackEntryPointCollider.IsTouchingLayers(11)
    void Update()
    {
        if ((Time.time >= enemyAttackTiming))
        {
            enemyAttack();
            enemyAnimator2.SetTrigger("Attack");
            enemyAttackTiming = Time.time + attackFloat / enemyAttackRate;
        }
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyAnimator2.SetTrigger("TakeHit");

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
        enemyAnimator2.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

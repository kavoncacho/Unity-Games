using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 550f;
    public float jumpForce = 930f;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public Transform leftCheck, leftCheck2, leftCheck3, leftCheck4, leftCheck5;
    public Transform rightCheck, rightCheck2, rightCheck3, rightCheck4, rightCheck5;
    public LayerMask BorderObjects;
    public LayerMask groundObjects;
    public float checkRadius;
    
    public Rigidbody2D rb;
    public Animator animator;
    private int facingRight = 1;
    private bool isJumping = false;
    private bool isGrounded = false;
    public static bool isOnLeftBorder = false;
    public static bool isOnRightBorder = false;
    private float moveDirection;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    public Animator combatAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Rigidbody2D combatRB;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && Character.Instance.weaponEquipped == true)
            {
                animator.SetTrigger("Attack");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (Character.Instance.currentHP <= 0)
        {
            animator.SetBool("isDead", true);
            Character.Instance.playerDeath();
        }
        /*
        if (Input.GetMouseButtonDown(0) && Character.Instance.weaponEquipped == true)
        {
            animator.SetTrigger("Attack");
            Attack();
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("this was reached");
            if (facingRight == 0)
            {
                facingRight--;
            }
            if (facingRight == 1)
            {
                facingRight--;
                facingRight--;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("this was reached");
            if (facingRight == 0)
            {
                facingRight++;
            }
            if (facingRight == -1)
            {
                facingRight++;
                facingRight++;
            }
        }

        if (facingRight == -1)
        {
            FlipCharacter();
        }
        
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
            Debug.Log("this was reached");
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
            Debug.Log("this was reached");
        }
        */
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        isOnLeftBorder = Physics2D.OverlapCircle(leftCheck.position, checkRadius, BorderObjects);
        isOnRightBorder = Physics2D.OverlapCircle(rightCheck.position, checkRadius, BorderObjects);
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        isJumping = false;

    }
    
    private void FlipCharacter()
    {
        if (facingRight == 1)
            facingRight = -1;
        else
            facingRight = 1;
        transform.Rotate(0f, 180f, 0f);
    }
    
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("You hit " + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(Character.Instance.damageOutput);
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

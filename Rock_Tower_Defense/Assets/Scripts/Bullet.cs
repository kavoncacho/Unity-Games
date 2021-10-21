using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletDamageOutput;

    public float speed = 8f;
    public float bulletAttackRange;

    public Rigidbody bulletRB;
    public Collider bulletCollider;
    public LayerMask enemyLayer;
    public Transform bulletAttackPoint;

    // Update is called once per frame
    void Update()
    {
        float currDistance = speed * Time.deltaTime;
        transform.position += transform.forward * currDistance;

        /*
        checks each frame if there is a collider of anything enemyLayer overlapping
        deals damage to said things
        
        Collider[] hitEnemy = Physics.OverlapSphere(bulletAttackPoint.position, bulletAttackRange, enemyLayer);
        foreach (Collider enemy in hitEnemy)
        {
            Debug.Log("You hit an enemy!");
            enemy.GetComponent<EnemyScript>().TakeDamage(bulletDamageOutput);
            GetComponent<Collider>().enabled = false;
            //Destroy(this);
        }
        */

    }

    void FixedUpdate()
    {
        /*
        checks each frame if there is a collider of anything enemyLayer overlapping
        deals damage to said things
        */
        Collider[] hitEnemy = Physics.OverlapSphere(bulletAttackPoint.position, bulletAttackRange, enemyLayer);
        foreach (Collider enemy in hitEnemy)
        {
            Debug.Log("You hit an enemy!");
            enemy.GetComponent<EnemyScript>().TakeDamage(bulletDamageOutput);
            GetComponent<Collider>().enabled = false;
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void OnDrawGizmosSelected()
    {
        if (bulletAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(bulletAttackPoint.position, bulletAttackRange);
    }

    public void bulletAttack()
    {
        /*
         * not sure if this is necessary
         * 
        Collider[] hitEnemy = Physics.OverlapSphere(bulletAttackPoint.position, bulletAttackRange, enemyLayer);
        foreach (Collider enemy in hitEnemy)
        {
            Debug.Log("You hit an enemy!");
            enemy.GetComponent<EnemyScript>().TakeDamage(bulletDamageOutput);
        }
        */
    }
}
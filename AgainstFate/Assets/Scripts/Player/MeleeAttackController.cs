using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;

    public float attackRange = 0.32f;
    public float standartDamage = 15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Attack();
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.gameObject.layer == 7)
                enemy.GetComponent<HP>().Damaging(standartDamage);
            else if (enemy.gameObject.layer == 8)
                enemy.GetComponent<CaveThrowBullet>().isDead = true;
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

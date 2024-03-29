using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;

    public float attackRange = 0.32f;
    public float standartDamage = 15f;
    public Animator animator;//переменная для переключения анимаций
    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking)
            {
                Attack();
                animator.Play("Fight");
                StartCoroutine(DoAttack());
                //Invoke("ResetFight", 5f);
            }
        }
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.gameObject.layer == 7)
                enemy.GetComponent<EnemyHP1>().GetDamage(standartDamage);
            else if (enemy.gameObject.layer == 8)
                enemy.GetComponent<CaveThrowBullet>().isDead = true;
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator DoAttack()
    {
        isAttacking = true;
        //attackHitBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        //attackHitBox.SetActive(false);

        isAttacking = false;
    }

}

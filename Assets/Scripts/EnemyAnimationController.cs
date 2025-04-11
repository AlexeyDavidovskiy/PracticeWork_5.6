using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Enemy enemy;

    private void Update()
    {
        WalkAnimation(enemy.EnemySpeed);
        AttackAnimation(enemy.IsAttacking);
    }

    private void WalkAnimation(float enemySpeed) 
    {
        if (enemySpeed > 0) 
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void AttackAnimation(bool isAttacking) 
    {
        animator.SetBool("IsAttacking", isAttacking);
    }
}

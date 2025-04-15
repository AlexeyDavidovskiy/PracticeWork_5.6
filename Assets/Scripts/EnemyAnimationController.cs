using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private StateAttack attackState;
    [SerializeField] private StatePatrol patrolState;
    [SerializeField] private StatePursue pursueState;

    private void Update()
    {
        WalkAnimation(patrolState.EnemySpeed, pursueState.EnemySpeed);
        AttackAnimation(attackState.IsAttacking);
    }

    private void WalkAnimation(float enemySpeedPatrol, float enemySpeedPursue) 
    {
        if (enemySpeedPatrol > 0 || enemySpeedPursue > 0) 
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

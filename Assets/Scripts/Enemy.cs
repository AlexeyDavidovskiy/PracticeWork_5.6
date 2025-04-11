using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IPatrolState, IPursueState, IAttackState
{
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private GameObject player;
    [SerializeField] private float minTimeToWalk;
    [SerializeField] private float maxTimeToWalk;
    [SerializeField] private float timeToWalgIfCharacterDetected;
    [SerializeField] private float visible;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private NavMeshAgent enemy;

    private float distanceBetweenEnemyAndPlayer;
    private float timeToWalk;
    private int randomPoint;
    private bool isAttacking;

    public bool IsAttacking => isAttacking;
    public float EnemySpeed => enemy.velocity.magnitude;

    private void Update()
    {
        distanceBetweenEnemyAndPlayer = Vector3.Distance(transform.position, player.transform.position);

        Attack(distanceBetweenEnemyAndPlayer);
        Patrol(distanceBetweenEnemyAndPlayer);
        Pursue(distanceBetweenEnemyAndPlayer);
    }

    public void Attack(float distance)
    {
        if (distance <= visible && distance <= distanceToAttack)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    public void Patrol(float distance)
    {
        if (distance > visible)
        {
            if (enemy.stoppingDistance <= 1)
            {
                timeToWalk -= Time.deltaTime;
                if (timeToWalk <= 0)
                {
                    timeToWalk = Random.Range(minTimeToWalk, maxTimeToWalk);
                    randomPoint = Random.Range(0, patrolPoints.Length);
                    enemy.destination = patrolPoints[randomPoint].transform.position;
                }
            }
        }
    }

    public void Pursue(float distance)
    {
        if (distance <= visible)
        {
            if (enemy.stoppingDistance <= 1)
            {
                enemy.destination = player.transform.position;
                timeToWalk = timeToWalgIfCharacterDetected;
            }
        }
    }
}

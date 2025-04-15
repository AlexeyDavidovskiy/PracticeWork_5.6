using UnityEngine;
using UnityEngine.AI;

public class StatePatrol : State
{
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private GameObject player;
    [SerializeField] private float minTimeToWalk;
    [SerializeField] private float maxTimeToWalk;
    [SerializeField] private float visible;
    [SerializeField] private NavMeshAgent enemy;

    private float distance;
    private float timeToWalk;
    private int randomPoint;

    public float EnemySpeed => enemy.velocity.magnitude;

    public override float Evaluate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        return distance > visible ? 1f : 0f;
    }

    public override void Execute()
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

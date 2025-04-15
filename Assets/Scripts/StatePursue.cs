using UnityEngine;
using UnityEngine.AI;

public class StatePursue : State
{
    [SerializeField] private GameObject player;
    [SerializeField] private float visible;
    [SerializeField] private NavMeshAgent enemy;

    private float distance;

    public float EnemySpeed => enemy.velocity.magnitude;

    public override float Evaluate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= visible ? 1f : 0f;
    }

    public override void Execute()
    {
        //if (distance <= visible) 
        //{
        //    if(enemy.stoppingDistance <= 1) 
        //    {
        //        enemy.destination = player.transform.position;
        //    }
        //}

        if (enemy.stoppingDistance <= 1)
        {
            enemy.destination = player.transform.position;
        }
    }
}

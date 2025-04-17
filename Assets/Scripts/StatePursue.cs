using UnityEngine;
using UnityEngine.AI;

public class StatePursue : State
{
    [SerializeField] private GameObject player;
    [SerializeField] private float visible;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private AnimationCurve utilityCurve;

    private float distance;

    public float EnemySpeed => enemy.velocity.magnitude;

    public override float Evaluate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        float normalizedDistance = Mathf.Clamp01(distance / visible);

        return utilityCurve.Evaluate(normalizedDistance);
    }

    public override void Execute()
    {
        if (enemy.stoppingDistance <= 1)
        {
            enemy.destination = player.transform.position;
        }
    }

    public override void Exit()
    {
        
    }
}

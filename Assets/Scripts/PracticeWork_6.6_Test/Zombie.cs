using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Zombie : MonoBehaviour
{
    private IPlayer _player;
    private NavMeshAgent _agent;

    [SerializeField] private float followDistance = 30f;

    [Inject]
    public void Construct(IPlayer player)
    {
        _player = player;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.Position);
        if (distance < followDistance)
        {
            _agent.SetDestination(_player.Position);
        }
    }
}

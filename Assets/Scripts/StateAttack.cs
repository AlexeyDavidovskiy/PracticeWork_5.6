using UnityEngine;

public class StateAttack : State
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private float visible;

    private float distance;
    private bool isAttacking;
    public bool IsAttacking => isAttacking;

    public override float Evaluate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= visible && distance <= distanceToAttack ? 1f : 0f;
    }

    public override void Execute()
    {
        isAttacking = true;
    }
}

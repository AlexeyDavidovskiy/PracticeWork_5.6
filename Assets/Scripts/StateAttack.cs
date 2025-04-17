using UnityEngine;

public class StateAttack : State
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private float visible;
    [SerializeField] private AnimationCurve utilityCurve;

    private float distance;
    private bool isAttacking;
    public bool IsAttacking => isAttacking;

    public override float Evaluate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > visible) 
        {
            return 0f;
        }
        
        float normalizedDistance = Mathf.Clamp01(distance / distanceToAttack);

        return utilityCurve.Evaluate(normalizedDistance);
    }

    public override void Execute()
    {
        isAttacking = true;
    }

    public override void Exit()
    {
        isAttacking = false; 
    }
}

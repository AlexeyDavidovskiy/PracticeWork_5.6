using UnityEngine;
using Zenject;

public class ScoreTracker : MonoBehaviour
{
    private int score;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<ZombieDiedSignal>(OnZombieKilled);
    }

    private void OnZombieKilled()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}


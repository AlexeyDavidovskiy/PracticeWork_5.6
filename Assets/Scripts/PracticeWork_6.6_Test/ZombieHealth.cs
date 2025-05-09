using UnityEngine;
using Zenject;

public class ZombieHealth : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;

    public void TakeDamage()
    {
        _signalBus.Fire(new ZombieDiedSignal());
        Destroy(gameObject);
    }
}



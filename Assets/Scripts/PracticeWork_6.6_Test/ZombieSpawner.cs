using UnityEngine;
using Zenject;

public class ZombieSpawner : MonoBehaviour
{
    private readonly IZombieFactory _zombieFactory;
    private readonly ZombieConfig _config;

    [Inject]
    public void Construct(IZombieFactory zombieFactory, ZombieConfig config)
    {
        _zombieFactory = zombieFactory;
        _config = config;
    }

    private void Start()
    {
        SpawnZombie();
    }

    public void SpawnZombie()
    {
        Vector3 spawnPoint = _config.spawnPoints[Random.Range(0, _config.spawnPoints.Length)];
        _zombieFactory.Create(spawnPoint);
    }
}


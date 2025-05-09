using UnityEngine;
using Zenject;

public class ZombieFactory : IZombieFactory
{
    private readonly DiContainer _container;
    private readonly Zombie _zombiePrefab;

    public ZombieFactory(DiContainer container, Zombie zombiePrefab)
    {
        _container = container;
        _zombiePrefab = zombiePrefab;
    }

    public Zombie Create(Vector3 spawnPosition)
    {
        return _container.InstantiatePrefabForComponent<Zombie>(_zombiePrefab, spawnPosition, Quaternion.identity);
    }

}




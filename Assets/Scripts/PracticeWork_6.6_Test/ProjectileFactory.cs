using UnityEngine;
using Zenject;

public class ProjectileFactory : IProjectileFactory
{
    private readonly Projectile.Factory _factory;

    public ProjectileFactory(Projectile.Factory factory)
    {
        _factory = factory;
    }

    public void Create(Vector3 position, Vector3 direction)
    {
        var projectile = _factory.Create(position, direction);
        projectile.Launch(direction);
    }
}



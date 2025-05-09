using UnityEngine;
using Zenject;

public class ZombieGameInstaller : MonoInstaller
{
    [Header("Prefabs")]
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Zombie _zombiePrefab;

    [Header("Configs")]
    [SerializeField] private ZombieConfig _zombieConfig;

    public override void InstallBindings()
    {
        // Сигналы
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<ZombieDiedSignal>();

        // Player bindings
        Container.Bind<IPlayer>().To<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerInputHandler>().FromComponentInHierarchy().AsSingle();

        // Projectile factory
        Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        Container.BindFactory<Vector3, Vector3, Projectile, Projectile.Factory>()
                 .FromComponentInNewPrefab(_projectilePrefab)
                 .WithGameObjectName("Projectile");

        // Zombie factory
        Container.Bind<IZombieFactory>().To<ZombieFactory>().AsSingle();
        Container.BindFactory<Vector3, Zombie, Zombie.Factory>()
                 .FromComponentInNewPrefab(_zombiePrefab)
                 .WithGameObjectName("Zombie");

        // Zombie config
        Container.Bind<ZombieConfig>().FromInstance(_zombieConfig).AsSingle();

        // Зависимости от Scene
        Container.Bind<ZombieSpawner>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ScoreTracker>().FromComponentInHierarchy().AsSingle();
    }
}




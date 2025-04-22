using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private bool useDummy = false;

    public override void InstallBindings()
    {
        if (useDummy)
        {
            Container.Bind<IGameConfig>().To<Dummy>().AsSingle().NonLazy();
        }
        else 
        {
            Container.Bind<IGameConfig>().To<GameConfigLoader>().AsSingle().WithArguments(gameConfig).NonLazy();
        }
    }
}

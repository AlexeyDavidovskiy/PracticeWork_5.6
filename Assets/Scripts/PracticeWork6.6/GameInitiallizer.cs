using UnityEngine;
using Zenject;

public class GameInitiallizer : MonoBehaviour
{
    [Inject]
    private IGameConfig gameConfig;

    private void Start()
    {
        Debug.Log($"Game: {gameConfig.GameTitle}");
        Debug.Log($"Max Enemies: {gameConfig.MaxEnemies}");
        Debug.Log($"Spawn Interval: {gameConfig.SpawnInterval}");
    }
}

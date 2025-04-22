using UnityEngine;

public class GameConfigLoader : IGameConfig
{
    private readonly GameConfig _config;

    public GameConfigLoader(GameConfig config) 
    {
        _config = config;
    }
    public int MaxEnemies => _config.maxEnemies;

    public float SpawnInterval => _config.spawnInterval;

    public string GameTitle => _config.gameTitle;
}

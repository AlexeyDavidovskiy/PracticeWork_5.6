using UnityEngine;

public class Dummy : IGameConfig
{
    public int MaxEnemies => 3;

    public float SpawnInterval => 5;

    public string GameTitle => "Dummy PracticeWork_6.6";
}

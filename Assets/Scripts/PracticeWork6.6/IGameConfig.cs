using UnityEngine;

public interface IGameConfig 
{
    public int MaxEnemies { get; }
    public float SpawnInterval { get; }
    public string GameTitle { get; }
}
  


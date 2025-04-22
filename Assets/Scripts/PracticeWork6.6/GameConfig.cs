using UnityEngine;


[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int maxEnemies = 10;
    public float spawnInterval = 2.5f;
    public string gameTitle = "My Favorite Game";
}

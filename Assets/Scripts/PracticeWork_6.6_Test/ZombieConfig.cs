using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ZombieConfig")]
public class ZombieConfig : ScriptableObject
{
    public GameObject zombiePrefab;
    public Vector3[] spawnPoints;
}


using UnityEngine;

public interface IZombieFactory
{
    Zombie Create(Vector3 spawnPosition);
}


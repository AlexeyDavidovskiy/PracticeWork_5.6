using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public Transform FirePoint { get; private set; }
    public Vector3 Position => transform.position;
}


using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public void Launch(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;
    }

    public class Factory : PlaceholderFactory<Vector3, Vector3, Projectile> { }
}



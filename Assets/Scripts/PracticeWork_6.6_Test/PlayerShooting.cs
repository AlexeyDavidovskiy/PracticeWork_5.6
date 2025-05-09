using UnityEngine;
using Zenject;

public class PlayerShooting : MonoBehaviour
{
    [Inject] private IPlayer _player;
    [Inject] private IProjectileFactory _projectileFactory;
    [Inject] private PlayerInputHandler _input;

    private void Update()
    {
        if (_input.IsShooting)
        {
            var firePosition = _player.FirePoint.position;
            var fireDirection = _player.FirePoint.forward;

            _projectileFactory.Create(firePosition, fireDirection);
        }
    }
}


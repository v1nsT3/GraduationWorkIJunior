using UnityEngine;
using UnityEngine.EventSystems;

namespace GraduationWork
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerWeapon _playerWeapon;
        [SerializeField] private Player _player;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_player.IsDead)
                return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_playerWeapon.IsAttack == false && EventSystem.current.IsPointerOverGameObject() == false)
                {
                    _playerWeapon.Attack();
                }
            }

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            if (_playerWeapon.IsAttack == false)
                _playerMovement.Move(vertical, horizontal);

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            _playerMovement.RotateToRay(ray);
        }
    }
}

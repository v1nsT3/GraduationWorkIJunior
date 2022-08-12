using GraduationWork;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Player _player;

    private Animator _animator;
    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;

    public bool IsAttack => _animator.GetBool(AnimatorController.Params.IsAttack);
    public Transform LeftHand => _leftHand;
    public Transform RightHand => _rightHand;

    public event UnityAction<float> EnduranceSpented;
    public event UnityAction<int> WeaponBuyed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetWeapon(_currentWeaponIndex);
    }

    private void Update()
    {
        if (_player.CurrentHealth <= 0)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_player.TryGetEndurance(_currentWeapon.EnduranceCasts) && _animator.GetBool(AnimatorController.Params.IsAttack) == false &&
                EventSystem.current.IsPointerOverGameObject() == false)
            {
                _animator.SetTrigger(AnimatorController.Params.AttackTrigger);
                EnduranceSpented?.Invoke(_currentWeapon.EnduranceCasts);
            }
        }
    }

    public void NextWeapon()
    {
        if(_currentWeaponIndex + 1 <= _weapons.Count - 1)
            _currentWeaponIndex++;
        else
            _currentWeaponIndex = 0;

        SetWeapon(_currentWeaponIndex);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex - 1 >= 0)
            _currentWeaponIndex--;
        else
            _currentWeaponIndex = _weapons.Count - 1;

        SetWeapon(_currentWeaponIndex);
    }

    private void SetWeapon(int index)
    {
        if(_currentWeapon != null)
            _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _weapons[index];
        _animator.SetInteger(AnimatorController.Params.WeaponId, _currentWeapon.WeaponId);
        _animator.SetTrigger(AnimatorController.Params.WeaponSwitch);
        _currentWeapon.gameObject.SetActive(true);
        _currentWeapon.Init(this);
    }

    public void TryBuyWeapon(Weapon weapon)
    {
        if (weapon.Price <= _player.Coins)
        {
            var coincidences = _weapons.Where(w => w.Label == weapon.Label).Count();

            if (coincidences == 0)
            {
                Weapon weapon1 = Instantiate(weapon, transform);
                _weapons.Add(weapon1);
                WeaponBuyed?.Invoke(weapon.Price);
            }
        }
    }

    //public void BuyWeapon(Weapon weapon)
    //{
    //    Weapon weapon1 = Instantiate(weapon, transform);
    //    _weapons.Add(weapon1);

    //    WeaponBuyed?.Invoke(weapon.Price);
    //}

    public void ResetWeapon()
    {
        if (_weapons.Count > 1)
        {
            for (int i = 1; i < _weapons.Count; i++)
            {
                Destroy(_weapons[i].gameObject);
                _weapons.RemoveAt(i);
            }
        }

        _currentWeaponIndex = 0;
        SetWeapon(_currentWeaponIndex);
    }
}

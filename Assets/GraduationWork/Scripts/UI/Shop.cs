using GraduationWork;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            WeaponView weaponView = Instantiate(_weaponView, _container);
            weaponView.Init(weapon);
            weaponView.SellButtonClick += OnSellButtonClick;
        }
    }

    private void OnSellButtonClick(WeaponView weaponView, Weapon weapon)
    {
        _player.TryBuyWeapon(weapon);
        weaponView.SellButtonClick -= OnSellButtonClick;
    }
}

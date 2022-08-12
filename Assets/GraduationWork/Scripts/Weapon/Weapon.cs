using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraduationWork
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _enduranceCosts;
        [SerializeField] private int _weaponId;
        [SerializeField] private int _price;
        [SerializeField] private string _label;
        [SerializeField] private Sprite _icon;

        protected PlayerWeapon PlayerWeapon;
        protected float Damage => _damage;
        public int WeaponId => _weaponId;
        public int Price => _price;
        public string Label => _label;
        public Sprite Icon => _icon;
        public float EnduranceCasts => _enduranceCosts;

        public abstract void Init(PlayerWeapon playerAttack);
    }
}


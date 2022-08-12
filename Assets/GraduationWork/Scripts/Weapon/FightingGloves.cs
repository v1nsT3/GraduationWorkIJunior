using GraduationWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGloves : Weapon
{    
    [SerializeField] private List<Glove> _gloves;

    private int _gloveCount = 2;
    
    private void OnEnable()
    {
        if(_gloves.Count == 0)
            _gloves.AddRange(GetComponentsInChildren<Glove>());

        foreach (var glove in _gloves)
        {
            glove.HitEnemy += OnHitEnemy;
            glove.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach (var glove in _gloves)
        {
            glove.HitEnemy -= OnHitEnemy;
            glove.gameObject.SetActive(false);
        }
    }

    public override void Init(PlayerWeapon playerWeapon)
    {
        PlayerWeapon = playerWeapon;

        _gloves[0].transform.parent = playerWeapon.LeftHand;
        _gloves[0].transform.localPosition = Vector3.zero;
        _gloves[1].transform.parent = playerWeapon.RightHand;
        _gloves[1].transform.localPosition = Vector3.zero;
    }

    private void OnHitEnemy(Glove glove, Enemy enemy)
    {
        if(PlayerWeapon.IsAttack)
            enemy.TakeDamage(Damage);
    }
}

using GraduationWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public override void Init(PlayerWeapon playerAttack)
    {
        PlayerWeapon = playerAttack;
        transform.parent = playerAttack.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (PlayerWeapon.IsAttack)
                enemy.TakeDamage(Damage);
        }
    }
}

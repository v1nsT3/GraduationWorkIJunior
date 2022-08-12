using UnityEngine;

public class Health : Specifications
{
    public bool IsDead => CurrentValue <= 0;

    public void TakeDamage(float damage)
    {
        DecreaseValue(damage);
    }
}

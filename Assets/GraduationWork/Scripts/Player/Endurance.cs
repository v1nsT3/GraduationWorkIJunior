using UnityEngine;

public class Endurance : Specifications
{
    public bool TryReduceEndurance(float enduranceValue)
    {
        if (CurrentValue >= enduranceValue)
        {
            DecreaseValue(enduranceValue);
            return true;
        }

        return false;
    }
}

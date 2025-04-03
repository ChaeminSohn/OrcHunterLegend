using UnityEngine;

public class PlayerHealth : LivingEntity
{
    public override void OnDamage(float damage)
    {
        Debug.Log("PlayerHealth");
    }
}

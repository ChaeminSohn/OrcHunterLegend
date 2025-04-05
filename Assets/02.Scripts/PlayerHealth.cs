using UnityEngine;

public class PlayerHealth : LivingEntity
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        anim.SetBool("isDamaged", true);
    }
}

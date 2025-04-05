using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float fullHP { get; protected set; }
    public float currentHP { get; protected set; }
    public bool isDead { get; protected set; }

    public event Action OnDeath; //사망시 실행되는 이벤트
    public virtual void OnDamage(float damage)
    {
        fullHP -= damage;
        if (fullHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDeath?.Invoke();
        isDead = true;
    }
}

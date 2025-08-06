using System;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _curHealth;

    public bool IsDead { get; private set; } = false;
    public float CurrentHealth
    {
        get => _curHealth;
        private set { _curHealth = value; }
    }
    public float MaxHealth
    {
        get => _maxHealth;
        private set { _maxHealth = value; }
    }


    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public event EventHandler<Health> OnHealthChanged;
    public event EventHandler<Health> OnDeath;

    public virtual void TakeDamage(Damage damage)
    {
        if (IsDead)
            return;

        CurrentHealth -= damage.DamageValue;

        OnHealthChanged?.Invoke(this, this);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
            OnDeath?.Invoke(this, this);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel
{
    public event Action<int> OnChangeHealth;
    public event Action OnLose;

    private readonly int _maxHealth;
    private int _currentHealth = 0;

    private readonly IPlayerDamageEffectProvider _damageEffectProvider;

    public HealthModel(int maxHealth, IPlayerDamageEffectProvider damageEffectProvider)
    {
        _maxHealth = maxHealth;
        _damageEffectProvider = damageEffectProvider;
    }

    public void Initalize()
    {
        AddHealth(5);
    }

    public void Dispose()
    {

    }

    public void RemoveHealth(int health)
    {
        if (_currentHealth == 0) return;

        _currentHealth -= health;

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
            OnLose?.Invoke();
        }

        _damageEffectProvider.PlayEffect();
        OnChangeHealth?.Invoke(_currentHealth);
    }

    public void AddHealth(int health)
    {
        if(_currentHealth == _maxHealth) return;

        _currentHealth += health;

        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        OnChangeHealth?.Invoke(_currentHealth);
    }

}

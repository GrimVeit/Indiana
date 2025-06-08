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
    private readonly ISoundProvider _soundProvider;

    public HealthModel(int maxHealth, IPlayerDamageEffectProvider damageEffectProvider, ISoundProvider soundProvider)
    {
        _maxHealth = maxHealth;
        _damageEffectProvider = damageEffectProvider;
        _soundProvider = soundProvider;
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
        }

        if(_currentHealth > 0)
        {
            _soundProvider.PlayOneShot("Damage");
        }
        else if(_currentHealth == 0)
        {
            _soundProvider.PlayOneShot("Die");
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

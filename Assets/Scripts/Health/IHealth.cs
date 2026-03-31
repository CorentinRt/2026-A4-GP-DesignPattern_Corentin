using System;
using UnityEngine;

public interface IHealth
{

    public event Action<float> OnHealthUpdated;
    public event Action OnDie;

    public abstract float GetHealth();
    public abstract bool IsDead();

    public abstract void TakeDamage(float value);

    public abstract void Heal(float value);
}

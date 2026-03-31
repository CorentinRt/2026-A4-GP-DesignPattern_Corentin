using System;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    #region Fields
    [Header("Proxy associated object")]
    [SerializeField] private IHealth _healthAssociated;

    #endregion

    #region Properties


    #endregion

    public event Action<float> OnHealthUpdated;
    public event Action OnDie;

    public float GetHealth()
    {
       return _healthAssociated.GetHealth();
    }

    public void Heal(float value)
    {
        _healthAssociated.Heal(value);
    }

    public bool IsDead()
    {
        return _healthAssociated.IsDead();
    }

    public void TakeDamage(float value)
    {
        _healthAssociated.TakeDamage(value);
    }
}

using Tanks.Complete;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    #region Fields
    [Header("Tank health ref")]
    [SerializeField] private TankHealth _tankHealth;

    [Header("UI Elements")]
    [SerializeField] private Slider m_Slider;
    [SerializeField] private Image m_FillImage;
    [SerializeField] private Color m_FullHealthColor = Color.green;    // The color the health bar will be when on full health.
    [SerializeField] private Color m_ZeroHealthColor = Color.red;

    #endregion


    #region Properties


    #endregion

    private void Awake()
    {
        if (_tankHealth != null)
        {
            _tankHealth.OnHealthUpdated += SetHealthUI;
            m_Slider.maxValue = _tankHealth.m_StartingHealth;
        }
    }

    private void OnDestroy()
    {
        if (_tankHealth != null)
        {
            _tankHealth.OnHealthUpdated -= SetHealthUI;
        }
    }

    private void SetHealthUI(float value)
    {
        // Set the slider's value appropriately.
        m_Slider.value = value;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, value / _tankHealth.m_StartingHealth);
    }
}

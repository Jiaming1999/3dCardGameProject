using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit_Stat : MonoBehaviour
{
    public float m_health = 100f;
    public Slider m_slider;

    private float m_currenthealth;
    private bool m_dead;

    void Start()
    {
        m_slider.maxValue = m_health;
        m_slider.value = m_health;
    }

    private void OnEnable() 
    {
        m_currenthealth = m_health;
        m_dead = false;

        SetHealthUI();
    }
    
    public void TakeDamage(float amount) 
    {
        m_currenthealth -= amount;
        SetHealthUI();
        if (m_currenthealth <= 0f && !m_dead) 
        {
            OnDeath();
        }
    }

    private void SetHealthUI() 
    {
        m_slider.value = m_currenthealth;
    }

    private void OnDeath() 
    {
        m_dead = true;
        Destroy(gameObject);
    }
}

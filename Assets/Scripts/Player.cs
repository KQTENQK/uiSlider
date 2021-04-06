using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public event UnityAction<float> ValueChanged;

    [SerializeField] private float _hitButtonDamage;
    [SerializeField] private float _healButtonHeal;
    [SerializeField] private Button _hitButton;
    [SerializeField] private Button _healButton;

    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    private void Start()
    {
        Health = 100;
        MaxHealth = 100;
    }

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(TakeDamage);
        _healButton.onClick.AddListener(TakeHeal);
    }

    private void OnDisable()
    {
        _hitButton.onClick.RemoveListener(TakeDamage);
        _healButton.onClick.RemoveListener(TakeHeal);
    }

    private void TakeDamage()
    {
        Health -= _hitButtonDamage;
        float healthToSliderDisplay = Health / MaxHealth;
        ValueChanged?.Invoke(healthToSliderDisplay);
    }

    private void TakeHeal()
    {
        Health += _healButtonHeal;
        float healthToSliderDisplay = Health / MaxHealth;
        ValueChanged?.Invoke(healthToSliderDisplay);
    }
}

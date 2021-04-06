using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _sliderRate;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.ValueChanged += ChangeValues;
    }

    private void OnDisable()
    {
        _player.ValueChanged -= ChangeValues;
    }

    private void ChangeValues(float currentPlayerHealth)
    {
        float currentSliderValue = _slider.value;
        StartCoroutine(MoveValue(currentPlayerHealth, currentSliderValue));
    }

    private IEnumerator MoveValue(float currentPlayerHealth, float currentSliderValue)
    {
        while (currentSliderValue != currentPlayerHealth)
        {
            currentSliderValue = Mathf.MoveTowards(currentSliderValue, currentPlayerHealth, Time.deltaTime * _sliderRate);
            _slider.value = currentSliderValue;
            yield return new WaitForEndOfFrame();
        }
    }
}

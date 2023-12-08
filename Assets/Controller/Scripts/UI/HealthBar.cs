using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Color Low;
    [SerializeField] Color High;

    public Slider slider;
    
    private void Start()
    {
        //SetMaxHealth();
        SetMaxHealth((int)SeasonManager.Instance.seasonDuration);
    }
    private void Update()
    {
        SetHealth((int)SeasonManager.Instance.duration);

    }
    private void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Color Low;
    [SerializeField] Color High;

    public Slider slider;
    float velocity = 0.0f;
    
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
        float currentScore;
        if (health < slider.value)
        {
             currentScore = Mathf.SmoothDamp(slider.value, health, ref velocity, 300 * Time.deltaTime);
        }else
        {
             currentScore = Mathf.SmoothDamp(slider.value, health, ref velocity, 50 * Time.deltaTime);
        }
        slider.value = currentScore;
        GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }
}

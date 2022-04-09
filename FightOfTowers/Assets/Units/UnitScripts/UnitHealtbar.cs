using UnityEngine;
using UnityEngine.UI;

/*
    Mikołaj Malich
    Adam Warzecha

    Unit Healtbar Script
*/
public class UnitHealtbar : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    private Slider slider;
    void Start()
    {   
        slider = image.GetComponent<Slider>();
        slider.maxValue = 10;
        slider.value = 10;
        fill.color = gradient.Evaluate(1f);
    }

    void Update()
    {   
        //currently no slider color change
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

/* 
    Switch to this later

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
*/
}

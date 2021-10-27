using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
      

    public void setMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void setMaxValue(int max,int start)
    {
        slider.maxValue = max;
        slider.value = start;
    }

    public void UpdateValue(int health)
    {
        slider.value = health;
    }
}

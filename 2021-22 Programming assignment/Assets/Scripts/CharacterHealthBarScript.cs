using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBarScript : MonoBehaviour
{
    public GameManager gm;
    // public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Start()
    {
        gm.Start();
    }
    public void SetMaxHealth(int health)
    {
        gm.slider.maxValue = health;
        //gm.slider.value = health;

        fill.color = gradient.Evaluate(3f);
    }
    public void SetHealth(int health)
    {
        gm.slider.value = health;

        fill.color = gradient.Evaluate(gm.slider.normalizedValue);
    }

}

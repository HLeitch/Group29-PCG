using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    /// <summary>
    /// Mask element of health bar
    /// </summary>
    public Image healthBarMask;


    /// <summary>
    /// Percentage of player health remaining 
    /// </summary>
   protected float healthPercentage;

    /// <summary>
    /// Percentage of HealthBar Visable. Should match healthPercentage unless recently changed
    /// </summary>
   protected float HealthBarValue;

   protected float originalMaskSize;

    /// <summary>
    /// Smooth damp velocity. Used in update when healthbar is shrinking
    /// </summary>

   protected float shrinkVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        originalMaskSize = healthBarMask.rectTransform.rect.width;
        healthPercentage = 1;
        HealthBarValue = 1;
    }


    public void ChangeHealth(float newHealthValue)
    {
        healthPercentage = newHealthValue;


    }

    public void SetHealthBarValue(float value)
    {

        healthBarMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalMaskSize*value);

    }

    // Update is called once per frame
    void Update()
    {
     if(HealthBarValue != healthPercentage)
     {
           

            float newHealthBarValue = Mathf.SmoothDamp(HealthBarValue,healthPercentage,ref shrinkVelocity,0.5f);

            HealthBarValue = newHealthBarValue;
            SetHealthBarValue(HealthBarValue);

     }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : UIHealthBar
{
    

    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        originalMaskSize = healthBarMask.rectTransform.rect.width;
        healthPercentage = 1;
        HealthBarValue = 1;

        canvas = FindObjectOfType<UIManager>().gameObject.GetComponent<Canvas>();


    }


    // Update is called once per frame
    void Update()
    {
        


             if (HealthBarValue != healthPercentage)
        {


            float newHealthBarValue = Mathf.SmoothDamp(HealthBarValue, healthPercentage, ref shrinkVelocity, 0.5f);

            HealthBarValue = newHealthBarValue;
            SetHealthBarValue(HealthBarValue);

        }


    }


   public void moveHealthBar(Transform newPosition)
    {

        gameObject.transform.position = Camera.main.WorldToScreenPoint(newPosition.position);

    }
}

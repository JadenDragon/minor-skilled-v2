using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }


    //updates the changes on health only when changes occurs
    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs someEvent)
    {    
        //find the healthBar UI
        //set the healthbar UI equal to the healthPercent on the X axis
        transform.Find("HealthContainer").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }

}

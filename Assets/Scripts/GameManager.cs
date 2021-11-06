using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //references the script to be used
    public static GameManager current;

    public HealthBar healthBar;

    private void Start()
    {
        HealthSystem playerHealth = new HealthSystem(100);

        healthBar.Setup(playerHealth);
        playerHealth.Damage(40);
        Debug.Log("Health: " + playerHealth.GetHealthPercent());
    }
    private void Awake()
    {
        current = this;
    }

    //define onItemPickup event
    public event Action onItemPickupTrigger;

    public void ItemPickup()
    {
        if (onItemPickupTrigger != null)
        {
            //Debug.Log("Item is here boy");
            onItemPickupTrigger();
            
        }
    }


}

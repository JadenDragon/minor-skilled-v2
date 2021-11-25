using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float downTime;
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    //default state is ready
    AbilityState state = AbilityState.ready;

    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    //pass the gameobject the script added to
                    //Activates ability when read
                    ability.Activate(gameObject);
                    //changes to the following state
                    state = AbilityState.active;
                    //change activeTime to ability activeTime;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.active:
                //check when the ability is no longer active
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    //when active time is over move change to cooldwon state
                    ability.CoolDown(gameObject);
                    state = AbilityState.cooldown;
                    downTime = ability.downTime;
                }
                break;
            case AbilityState.cooldown:
                if (downTime > 0)
                {
                    downTime -= Time.deltaTime;
                }
                else
                {
                    //when cooldown time is over set ability to ready
                    state = AbilityState.ready;
                }
                break;
        }

        
    }
}

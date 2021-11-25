using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float downTime;
    public float activeTime;

    //parameters references the gameObject holding the ability
    public virtual void Activate(GameObject parent) { }

    public virtual void CoolDown(GameObject parent) { }
}

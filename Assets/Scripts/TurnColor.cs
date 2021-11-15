using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColor : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onClicked += ChangeColor;
    }

    private void OnDisable()
    {
        EventManager.onClicked -= ChangeColor;
    }

    void ChangeColor()
    {
        Color col = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = col;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnEnable()
    {
        //subscribes Teleporting to onClicked event
        //called when object is enabled or created
        EventManager.onClicked += Teleporting;
    }

    private void OnDisable()
    {
        //unsubscribes function from event
        //called when object is destroyed or disabled
        EventManager.onClicked -= Teleporting;
    }

    //set your position
    //move position.Y in a set range
    //set new position into object
    void Teleporting()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(520.3f, 930.0f);
        transform.position = position;
    }
}

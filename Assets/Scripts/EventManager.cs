using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction onClicked;
    // Start is called before the first frame update

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            //call onClicked() if not NULL
            if(onClicked != null)
            {
                onClicked();
            }
        }
    }
}

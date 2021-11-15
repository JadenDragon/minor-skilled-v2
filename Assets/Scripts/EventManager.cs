using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
<<<<<<< HEAD
    //ClickAction event type
    public delegate void ClickAction();
    //event variable onClicked
    public static event ClickAction onClicked;
=======
    public delegate void ClickAction();
    public static event ClickAction onClicked;
    // Start is called before the first frame update
>>>>>>> Developer

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            //call onClicked() if not NULL
            if(onClicked != null)
            {
<<<<<<< HEAD
                //event is used as a function to invoke the event
=======
>>>>>>> Developer
                onClicked();
            }
        }
    }
<<<<<<< HEAD

    
=======
>>>>>>> Developer
}

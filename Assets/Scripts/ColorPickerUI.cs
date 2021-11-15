using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorPickerUI : MonoBehaviour
{
    public GameObject target;
    private Material targetMaterial;
    private GraphicRaycaster raycast;
    private PointerEventData pointer;
    private EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            //get the material of the target
            targetMaterial = target.GetComponent<Renderer>().material;
        }
        //get the raycaster and eventsystem of the canvas
        raycast = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        pointer = new PointerEventData(eventSystem);
        pointer.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycast.Raycast(pointer, results);

        foreach(RaycastResult swatch in results)
        {
            if (swatch.gameObject.GetComponent<Image>().color != null)
            {
                changeColor(swatch.gameObject.GetComponent<Image>().color);
                Debug.Log(swatch);
            }
        }
    }

    void changeColor(Color myColor)
    {
        targetMaterial.color = myColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolTipText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject toolTip;     //the tool tip gameObject
    [SerializeField]
    Canvas playerCanvas;    //the canvas associated with the current player
    [SerializeField]
    string descriptionText; //the text that will appear on the tool tip

    GameObject toolTipObject;   //the control variable for the instantiated tool tip
    float toolTipDelay = 0.3f;  //amount of time before the tool tip dissapears after deactivating it
    bool isPointerEntered;  //checks if the mouse is hovering over this object

    IEnumerator ShowToolTip(float delay)
    {
        yield return new WaitForSeconds(delay); //delay the tool tip being shown

        if (isPointerEntered)   //if the mouse is still hovering over this object after the delay, show the tool tip
        {
            Vector2 toolTipLocation = new Vector2(transform.position.x, transform.position.y + 100);    //set the position of the tool tip
            toolTipObject = Instantiate(toolTip, playerCanvas.transform);  //create the tool tip
            toolTipObject.transform.position = toolTipLocation; //change position to preset position
            toolTipObject.transform.GetComponentInChildren<Text>().text = descriptionText;  //set the tool tip's text to the description text
        }
    }

    public void OnPointerEnter(PointerEventData eventData)  //when the mouse hovers over the object this script is attached to
    {
        isPointerEntered = true;
        StartCoroutine(ShowToolTip(toolTipDelay));  //show tool tip
    }

    public void OnPointerExit(PointerEventData eventData)   //when the mouse hovers off of the object this script is attached to
    {
        isPointerEntered = false;
        Destroy(toolTipObject, toolTipDelay);   //let the tool tip stay for a bit then destroy it
    }
}

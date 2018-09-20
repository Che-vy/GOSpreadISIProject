using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{

    public InputPkg GetInputs()
    {
        InputPkg inputPkg = new InputPkg();

        inputPkg.currentMousePos = Input.mousePosition;
        float x = Input.GetAxis("Horizontal"); // get left right for the camera to move
        float z = Input.GetAxis("Vertical"); // get up down for the camera to move
        inputPkg.cameraDirectionPressed = new Vector3(x, 0, z);
        inputPkg.objectSelected = getOnClickMousePosWithRayCast();

        return inputPkg;
    }

    public class InputPkg
    {
        public Vector3 currentMousePos; // keep track of the mouse position (current position)
        public Vector3 cameraDirectionPressed; // key pressed to move the camera around
        public GameObject objectSelected; // object selected by mouse on click with raycast

        public override string ToString()// to see what is happening in the package
        {
            return "Mouse current position at : " + currentMousePos + "  / " +
                "ArrowKey pressed for camera (left/right,up,down, forward, backward): " + cameraDirectionPressed + ".  ";
        }
    }

    public GameObject getOnClickMousePosWithRayCast() // function to get mouse click position (need raycast to get the Z)
    {
        GameObject toRet = null;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse); // transform 2D position of the mouse to 3D position for the mouse
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity)) //if hit return true
            {
                
                toRet = hit.transform.gameObject; // the hit return the game object it hits

                Debug.Log(""+ toRet.name);
            }
            else
            {
                Debug.Log("No object was hit by the raycast");
            }

        }
   
        return toRet;
    }
}

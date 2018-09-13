using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public InputPkg GetInputs()
    {
        InputPkg inputPkg = new InputPkg();

        inputPkg.currentMousePos = Input.mousePosition;
        float x = Input.GetAxis("Horizontal"); // get left right for the camera to move
        float z = Input.GetAxis("Vertical"); // get up down for the camera to move

        return inputPkg;
    }


    public class InputPkg
    {
        public Vector3 mousePosOnClick; // get position where the mouse clicked
        public Vector3 currentMousePos; // keep track of the mouse position (current position)
        public Vector2 cameraDirectionPressed; // key pressed to move the camera around

        public override string ToString()
        {
            return "Mouse current position at : " + currentMousePos + "  / Mouse click position at : " + mousePosOnClick +
                "ArrowKey pressed for camera (left/right,up,down, forward, backward): " + cameraDirectionPressed + ".  ";
        }
    }

    public Vector3 getOnClickMousePosWithRayCast()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            gameObject.transform.position = hit.point;
        }
    }
}

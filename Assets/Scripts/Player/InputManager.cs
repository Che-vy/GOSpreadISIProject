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
        inputPkg.cameraDirectionPressed = new Vector3(x, 0, z); //  **** la valeur y du vecteur a besoin de la hauteur de base (hauteur qui ne changera jamais ****
        inputPkg.mousePosOnClick = getOnClickMousePosWithRayCast();

        return inputPkg;
    }


    public class InputPkg
    {
        public Vector3 mousePosOnClick; // get position where the mouse clicked
        public Vector3 currentMousePos; // keep track of the mouse position (current position)
        public Vector3 cameraDirectionPressed; // key pressed to move the camera around

        public override string ToString()
        {
            return "Mouse current position at : " + currentMousePos + "  / Mouse click position at : " + mousePosOnClick +
                "ArrowKey pressed for camera (left/right,up,down, forward, backward): " + cameraDirectionPressed + ".  ";
        }
    }

   public Vector3 getOnClickMousePosWithRayCast() // function to get mouse click position (need raycast to get the Z)
   {

       Vector3 toRet = new Vector3(0,0,0);
       Vector3 mouse = Input.mousePosition;
       Ray castPoint = Camera.main.ScreenPointToRay(mouse); // transform 2D position of the mouse to 3D position for the mouse
       RaycastHit hit;
       if (Physics.Raycast(castPoint, out hit, Mathf.Infinity)) //if hit return true
       {
            Debug.Log("Raycast hit");
            toRet = hit.point;
       }
        return toRet;
   }
}

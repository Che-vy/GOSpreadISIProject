using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    public bool CanItMove(BasePawnsClass pawn) //look if the selected unit can move
    {
        bool canItMove = false;//check if the unit can move
        bool unitHaveMovementPointAvailable = false;// check if the unit can move (so we dont move the same unit more then once)
        bool intersectionExist = false; // check if there is an intesection so we can place the pawn
        bool landingPlaceIsFree = false;// check if there is a pawn occupying the place
        bool secondLandindPlaceIsFree = false; // for the zip movement
        

        // check for movement available (bits and relay have 1, zips have 2)

        //check up for unit that have 1 movement
        if (pawn.movementAvailable > 0)
        {
            unitHaveMovementPointAvailable = true;

            //Checks for existing landing space(intersection)
            if (GridManager.Instance.grid_blueprint != null)
            {
                if ((pawn.positionInGridArray.y + 2) >= GridManager.Instance.grid_blueprint.gridLayout.Length)
                {
                    Debug.Log("Can't move down, no landing zone");
                }
                else
                {
                    Debug.Log("Intersection exist bot");
                    intersectionExist = true;
                    //Check if theres a pawn at the landing zone
                    if (UnitGridManager.Instance.unitGrid.unitGrid[(int)pawn.positionInGridArray.x, ((int)pawn.positionInGridArray.y + 2)] == null)
                    {
                        landingPlaceIsFree = true;
                        Debug.Log("Top landing place is free");
                    }
                }
                if ((pawn.positionInGridArray.y - 2) < 0)
                {
                    Debug.Log("Can't move up, no landing zone");
                }
                else
                {
                    Debug.Log("Intersection exist top");
                    intersectionExist = true;
                    //Check if theres a pawn at the landing zone
                    if (UnitGridManager.Instance.unitGrid.unitGrid[(int)pawn.positionInGridArray.x, ((int)pawn.positionInGridArray.y - 2)] == null)
                    {
                        landingPlaceIsFree = true;
                        Debug.Log("Bot landing place is free");
                    }
                }
                if (pawn.positionInGridArray.x + 2 >= GridManager.Instance.grid_blueprint.gridLayout.Length)
                {
                    Debug.Log("Can't move right, no landing zone");
                }
                else
                {
                    Debug.Log("Intersection exist right");
                    intersectionExist = true;
                    //Check if theres a pawn at the landing zone
                    if (UnitGridManager.Instance.unitGrid.unitGrid[(int)pawn.positionInGridArray.x + 2, ((int)pawn.positionInGridArray.y)] == null)
                    {
                        landingPlaceIsFree = true;
                        Debug.Log("Right landing place is free");
                    }
                }
                if (pawn.positionInGridArray.x - 2 < 0)
                {
                    Debug.Log("Can't move left, no landing zone");
                }
                else
                {
                    Debug.Log("Intersection exist left");
                    intersectionExist = true;
                    //Check if theres a pawn at the landing zone
                    if (UnitGridManager.Instance.unitGrid.unitGrid[(int)pawn.positionInGridArray.x - 2, ((int)pawn.positionInGridArray.y)] == null)
                    {
                        landingPlaceIsFree = true;
                        Debug.Log("Left landing place is free");
                    }
                }

            }

        }

        if ((pawn.pawnType == PawnTypes.Bit || pawn.pawnType == PawnTypes.Relay) && intersectionExist && landingPlaceIsFree && unitHaveMovementPointAvailable)
        {
            canItMove = true;
        }
        // else if (pawn.pawnType == PawnTypes.Zip)

        return canItMove;
    }












}

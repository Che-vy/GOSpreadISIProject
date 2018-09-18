using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    public bool CanItMove(BasePawnsClass pawn) //look if the selected unit can move
    {
        int scale = 2;

        bool canItMove = false;//check if the unit can move
        bool unitHaveMovementPointAvailable = false;// check if the unit can move (so we dont move the same unit more then once)
        bool intersectionExist = false; // check if there is an intesection so we can place the pawn
        bool landingPlaceIsFree = false;// check if there is a pawn occupying the place
        bool zipCanMove = false;

        Vector2Int gridIndex;
        List<Vector2Int> dir = new List<Vector2Int>()
        {
            new Vector2Int(0,1),//down
            new Vector2Int(0,-1),//up
            new Vector2Int(1,0),//right
            new Vector2Int(-1,0)//left
        };

        //check up for unit that have 1 movement
        foreach (Vector2Int v in dir)
        {
            gridIndex = pawn.positionInGridArray + (v * scale);

            if (pawn.movementAvailable > 0)
            {
                unitHaveMovementPointAvailable = true;


                //if the position exist in the grid
                if ((gridIndex.x >= 0 && gridIndex.x <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(0)) && (gridIndex.y >= 0 && gridIndex.y <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(1)))
                {
                    intersectionExist = true;
                    //if landing space already have a unit on it
                    if (UnitGridManager.Instance.unitGrid.unitGrid[gridIndex.x, gridIndex.y] == null)
                    {
                        landingPlaceIsFree = true;

                        if (pawn.pawnType == PawnTypes.Zip)
                        {
                            gridIndex = gridIndex + (v * scale);
                            if ((gridIndex.x >= 0 && gridIndex.x <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(0)) && (gridIndex.y >= 0 && gridIndex.y <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(1)))
                            {
                                if (UnitGridManager.Instance.unitGrid.unitGrid[gridIndex.x, gridIndex.y] == null)
                                {
                                    zipCanMove = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        if ((pawn.pawnType == PawnTypes.Bit || pawn.pawnType == PawnTypes.Relay) && intersectionExist && landingPlaceIsFree && unitHaveMovementPointAvailable)
        {
            canItMove = true;
        }
        else if (pawn.pawnType == PawnTypes.Zip && zipCanMove)
        {
            canItMove = true;
        }

        return canItMove;
    }
}

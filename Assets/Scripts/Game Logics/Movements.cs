using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements
{
   static public GameObject LastObjetSelectionne;
   static public List<GameObject> posActiver;


    public static bool CanItMove(BasePawnsClass pawn) //look if the selected unit can move
    {
        int scale = 2;

        bool canItMove = false;//check if the unit can move
        bool unitHaveMovementPointAvailable = false;// check if the unit can move (so we dont move the same unit more then once)
        bool intersectionExist = false; // check if there is an intesection so we can place the pawn
        bool landingPlaceIsFree = false;// check if there is a pawn occupying the place
        bool zipCanMove = false;//second check only for the zip



        Vector2Int gridIndex;
        posActiver = new List<GameObject>();
        List<Vector2Int> dir = new List<Vector2Int>()
        {
            new Vector2Int(0,1),//down
            new Vector2Int(0,-1),//up
            new Vector2Int(1,0),//right
            new Vector2Int(-1,0)//left
        };
        //check up for unit that have 1 movement

        if (pawn.movementAvailable > 0)
        {
            foreach (Vector2Int v in dir)
            {

                gridIndex = pawn.positionInGridArray + (v * scale);
                unitHaveMovementPointAvailable = true;


                //if the position exist in the grid
                if (GridManager.Instance.grid_blueprint != null)
                {
                    if ((gridIndex.x >= 0 && gridIndex.x <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(0)) && (gridIndex.y >= 0 && gridIndex.y <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(1)))
                    {
                        intersectionExist = true;
                        //if landing space already have a unit on it
                        if (UnitGrid.Instance.unitGrid != null)
                        {
                            if (UnitGrid.Instance.unitGrid[gridIndex.x, gridIndex.y].playerNum == 0)
                            {
                                landingPlaceIsFree = true;
                                //this is where we highlight the ok zones
                                GridManager.Instance.ActivateLight(new Vector2Int(gridIndex.x, gridIndex.y));
                                posActiver.Add(GridManager.Instance.grid_objects[gridIndex.x, gridIndex.y]);
                                Debug.Log("pos available" + gridIndex);

                                // check for unit that have 2 movement
                                if (pawn.pawnType == PawnTypes.Zip)
                                {

                                    foreach (Vector2Int v2 in dir)
                                    {
                                        //loop on all directions again for the 2nd movement
                                        gridIndex = gridIndex + (v * scale);
                                        if ((gridIndex.x >= 0 && gridIndex.x <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(0)) && (gridIndex.y >= 0 && gridIndex.y <= GridManager.Instance.grid_blueprint.gridLayout.GetUpperBound(1)))
                                        {
                                            if (UnitGrid.Instance.unitGrid[gridIndex.x, gridIndex.y].playerNum == 0)
                                            {
                                                GameObject test2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                test2.transform.position = GridManager.Instance.grid_objects[gridIndex.x, gridIndex.y].transform.position;
                                                //where we highlight the second zone
                                                zipCanMove = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.Log("pos not available");
                            }
                        }
                        else
                        {
                            Debug.Log("unit grid is null");
                        }
                    }
                }
                else
                {
                    Debug.Log("gridblueprint is null");
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
    public static bool CanSelectUnit(GameObject selectedPawn, int phase)
    {
        bool canBeSelected = false;//unit cant be selected if it's not the player unit

        if ((selectedPawn.tag == "Units" || selectedPawn.tag == "Kernel") && selectedPawn.GetComponent<BasePawnsClass>().playerNum == PlayerManager.Instance.playerTurn)
        {
            if (LastObjetSelectionne != null)
            { 
               ParticleManager.StopParticleSystem(LastObjetSelectionne.transform.GetChild(0).gameObject);
                //LastObjetSelectionne.GetComponentInChildren<ParticleSystem>().Stop();

            }
            canBeSelected = true;
            // selectedPawn.GetComponentInChildren<ParticleSystem>().Play();
            ParticleManager.PlayParticleSystem(selectedPawn.transform.GetChild(0).gameObject);
            LastObjetSelectionne = selectedPawn;

            UIManager.Instance.ShowUnitsUI(selectedPawn, phase);

        }
        return canBeSelected;
    }
}


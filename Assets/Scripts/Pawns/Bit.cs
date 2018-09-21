using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : BasePawnsClass
{


    public void Initialize(Vector2Int arrayPos, int id)
    {
        pawnType = PawnTypes.Bit;
        quickPawnDefinition = "Basic pawn created from the Kernels. Can be upgraded into Zips or Relays. This unit can move 1 tile per turn and have a range of 1.";
        movementValue = 1;
        rangeValue = 1;
        playerNum = id;
        level = 1;
        prefabsModel = "Bit";
        hasBeenEaten = false;
        movementAvailable = 1;
        positionInGridArray = arrayPos;
    }

}

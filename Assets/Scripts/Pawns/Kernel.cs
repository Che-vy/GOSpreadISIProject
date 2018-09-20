using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kernel : BasePawnsClass
{

    public void Initialize(Vector2Int pos,int id)
    {
        pawnType = PawnTypes.Kernel;
        quickPawnDefinition = "Produce Bits(1 per Kernel)/Upgrade an existing pawn and allow the player to get another movement(+1 movement per Kernel)";
        positionInGridArray = pos;
        movementValue = 1;
        movementAvailable = 1;
        rangeValue = 1;
        playerNum = id;
        level = 3;
        prefabsModel = "Kernel";
        hasBeenEaten = false;
    }

}

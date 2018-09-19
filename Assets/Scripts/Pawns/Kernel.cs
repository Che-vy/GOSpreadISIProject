using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kernel : BasePawnsClass
{

    public void Initialize()
    {
        pawnType = PawnTypes.Kernel;
        quickPawnDefinition = "Produce Bits(1 per Kernel)/Upgrade an existing pawn and allow the player to get another movement(+1 movement per Kernel)";

        movementValue = 0;
        rangeValue = 1;
        playerNum = 0;
        level = 3;
        prefabsModel = "Kernel";
        hasBeenEaten = false;
    }

}

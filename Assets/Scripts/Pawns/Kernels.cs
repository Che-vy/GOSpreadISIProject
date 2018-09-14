using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kernels : BasePawnsClass
{

    public Kernels(Vector3 _pos)
    {
        pawnType = PawnTypes.Kernel;
        quickPawnDefinition = "Produce Bits(1 per Kernel)/Upgrade an existing pawn and allow the player to get another movement(+1 movement per Kernel)";

        movementValue = 0;
        rangeValue = 1;
        playerNum = 0;
        level = 3;
        gameObject.transform.position = _pos;
        prefabsModel = "Kernel";
        hasBeenEaten = false;
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bits : BasePawnsClass
{
    public Bits(Vector3 _pos)
    {
        pawnType = PawnTypes.Bit;
        quickPawnDefinition = "Basic pawn created from the Kernels. Can be upgraded into Zips or Relays. This unit can move 1 tile per turn and have a range of 1.";
        movementValue = 1;
        rangeValue = 1;
        playerNum = 0;
        level = 1;
        gameObject.transform.position = _pos;
        prefabsModel = "Bit";
        hasBeenEaten = false;
        movementAvailable = 1;
    }

}

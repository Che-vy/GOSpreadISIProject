using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zips : BasePawnsClass
{

    public Zips(Vector3 _pos)
    {
        pawnType = PawnTypes.Zip;
        quickPawnDefinition = "Upgraded form of the Bit. Can be upgraded into a Kernel if enough territories are possessed." +
                              "This unit can move 2 tiles per turn and have a range of one. " +
                              "It is also the only unit that can kills other unit by passing above an enemy unit like in checkers";

        movementValue = 2;
        rangeValue = 1;
        playerNum = 0;
        level = 2;
        gameObject.transform.position = _pos;
        prefabsModel = "Zip";
        hasBeenEaten = false;
        movementAvailable = 2;
    }


}

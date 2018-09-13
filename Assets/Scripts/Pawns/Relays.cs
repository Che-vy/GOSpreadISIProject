﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relays : BasePawnsClass
{

    public Relays(Vector3 _pos)
    {
        PawnTypes pawnType = PawnTypes.Relay;
        quickPawnDefinition = "Upgraded form of the Bit.Can be upgraded into a Kernel if enough territories are possessed."+
                              "This unit can move 1 tile per turn and have a range of 2";

        movementValue = 1;
        rangeValue = 2;
        playerNum = 0;
        level = 2;
        gameObject.transform.position = _pos;
        prefabsModel = "Relay";
        hasBeenEaten = false;
    }
    
}





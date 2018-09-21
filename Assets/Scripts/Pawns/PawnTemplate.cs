using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnTemplate : BasePawnsClass {

    public void Initialize(Vector2Int arrayPos)
    {
        pawnType = PawnTypes.Template;
        movementValue = 0;
        rangeValue = 0;
        level = 0;
        hasBeenEaten = false;
        movementAvailable = 0;
        positionInGridArray = arrayPos;
    }

}

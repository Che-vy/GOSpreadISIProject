using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PawnTypes { Bit, Zip, Relay, Kernel}
public class BasePawnsClass : MonoBehaviour {

    public PawnTypes pawnType; //define type of the pawn, see enum above
    public string quickPawnDefinition; // quick definition of the pawn, how it behave in the game. Definition can be use for UI purposes (how to play, pawns UI)


    public int movementValue; // number of spaces it can move on the map
    public int rangeValue; // number of spaces it can bridge with other units to form a territory
    public int playerNum; // define which player the units belong to
    public int level; // level of the piece : bits are lvl 1, relays and zips are lvl 2 and kernels are lvl 3. Can use lvl too look if it can upg into something
    public Vector3 pos; // current position of the pawn => need to create a tool to change pawns positions.
    public string prefabsModel; // name of the prefab (need to be the actual name of the prefab related to the pawn) for easier instanciation
    public bool hasBeenEaten; // if the pawn is alive or not


    public void Move(Vector3 newPosition) // virtual fonction to move the pawns
    {
        if(pawnType != PawnTypes.Kernel)
        {
            gameObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Kernel cannot move.");
        }
    }
}

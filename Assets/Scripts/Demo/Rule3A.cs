using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule3A
{
    private static int gridLimit = UnitGrid.Instance.unitGrid.GetUpperBound(0);

    #region Singleton
    private static Rule3A instance = null;

    private Rule3A()
    {
    }

    public static Rule3A Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Rule3A();
            }
            return instance;
        }
    }
    #endregion

    public void MovePiece(Vector2Int arrayPos, Vector2Int destination)
    {
        UnitGrid.Instance.unitGrid[destination.x, destination.y] = UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y];

        UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y] = null;
        //UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y] = new BasePawnsClass();
        UnitGrid.Instance.unitGridGO[destination.x, destination.y] = UnitGrid.Instance.unitGridGO[arrayPos.x, arrayPos.y];
        //Vector2Int worldSpace new Vector2Int((int)GridManager.Instance.GetGridComponentPosition(destination.x, destination.y).position.x, (int)GridManager.Instance.GetGridComponentPosition(destination.x, destination.y).position.y);
        //MonoBehaviour.StartCoroutine(LerpMovementTool(false, UnitGrid.Instance.unitGridGO[arrayPos.x, arrayPos.y].gameObject, , 2f);
      //  UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y] = ;


    }
    /// <summary>
    /// Coroutine for movement lerp.
    /// </summary>
    /// <param name="isMoving">Set to false when calling on inanimate object</param>
    /// <param name="toMove">The unit's GameObject to be moved</param>
    /// <param name="destination">The GameObject of the grid component chosen</param>
    /// <param name="time">Time it takes to complete trajectory</param>
    public IEnumerator LerpMovementTool(bool isMoving, GameObject toMove, GameObject destination, float time)
    {
        if (!isMoving)
        {
            isMoving = true;
            float t = 0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime / time;
                toMove.transform.position = Vector3.Lerp(toMove.transform.position, new Vector3(destination.transform.position.x, destination.transform.position.y + .75f, destination.transform.position.z), t);
                yield return new WaitForSeconds(0.05f);
            }

            isMoving = false;
        }
    }

    public void RunMovementCheck(Vector2Int arrayPos, int range)
    {
        List<Vector2Int> potentialDestinations = new List<Vector2Int>();

        for (int s = 2; s <= range; s += 2)
        {
            if (arrayPos.x - s >= 0)
            {             
                    if (UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x - s, arrayPos.y)).playerNum == 0 )
                    {
                      
                        GridManager.Instance.ActivateLight(new Vector2Int(arrayPos.x - s, arrayPos.y)); //Activate light particle for potential destination approved
                    }
                
            }
            if (arrayPos.x + s <= gridLimit)
            {

                if (UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x + s, arrayPos.y)).playerNum == 0)
                {
                    //potentialDestinations.Add(new Vector2Int(arrayPos.x + x, arrayPos.y));
                    GridManager.Instance.ActivateLight(new Vector2Int(arrayPos.x + s, arrayPos.y)); //Activate light particle for potential destination approved
                }
                

            }
            if (arrayPos.y + s <= range)
            {

                if (UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x, arrayPos.y - s)).playerNum == 0)
                {

                    GridManager.Instance.ActivateLight(new Vector2Int(arrayPos.x, arrayPos.y - s)); //Activate light particle for potential destination approved
                }
            }
            if (arrayPos.y + s <= gridLimit)
            {
                    if (UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x, arrayPos.y + s)).playerNum == 0)
                    {
                        //potentialDestinations.Add(new Vector2Int(arrayPos.x + x, arrayPos.y));
                        GridManager.Instance.ActivateLight(new Vector2Int(arrayPos.x, arrayPos.y + s)); //Activate light particle for potential destination approved
                    }
            }
        }
    }

    public void RunTerritoryCheck(int range, int player)
    {
        int x = 0;
        while (x + 2 <= gridLimit)
        {
            int y = 0;
            while (y + 2 <= gridLimit)
            {
                if (UnitGrid.Instance.unitGrid[x, y].playerNum == player)
                {
                    int multiplier = 2;
                    while (x + multiplier <= gridLimit && y + multiplier <= gridLimit)
                    {
                        if (UnitGrid.Instance.GetUnit(new Vector2Int(x + multiplier, y + multiplier)).playerNum == player)
                        {
                            int rangeYMinus = 2;
                            while (rangeYMinus <= range)
                            {
                                if (y + multiplier - rangeYMinus == y && UnitGrid.Instance.GetUnit(new Vector2Int(x + multiplier, y + multiplier - rangeYMinus)).playerNum == player)
                                {
                                    int rangeXMinus = 2;
                                    while (rangeXMinus <= range)
                                    {
                                        if (x + multiplier - rangeXMinus == x && UnitGrid.Instance.GetUnit(new Vector2Int(x + multiplier - rangeXMinus, y + multiplier - rangeYMinus)).playerNum == player)
                                        {
                                            int rangeYPlus = 2;
                                            while (rangeYPlus <= range)
                                            {
                                                if (UnitGrid.Instance.GetUnit(new Vector2Int(x, y + rangeYPlus)).playerNum == player)
                                                {
                                                    int rangeXPlus = 2;
                                                    while (rangeXPlus <= range)
                                                    {
                                                        if (UnitGrid.Instance.GetUnit(new Vector2Int(x + rangeXPlus, y + rangeYPlus)).playerNum == player)
                                                        {
                                                            for (int i = x; i <= x + multiplier; i++)
                                                            {
                                                                for (int j = y; j <= y + multiplier; j++)
                                                                {
                                                                    if (j % 2 != 0 && i % 2 != 0)
                                                                    {
                                                                        PlayerManager.Instance.getPlayer(player).zone++;
                                                                        if (TerritoryGridManager.Instance.GetOwner(new Vector2Int(i, j)) != 0 && TerritoryGridManager.Instance.GetOwner(new Vector2Int(i, j)) != player) 
                                                                        {
                                                                            switch (player) {
                                                                                case 1:
                                                                                    PlayerManager.Instance.getPlayer((int)Zone.Player2).zone--;
                                                                                    break;
                                                                                case 2:
                                                                                    PlayerManager.Instance.getPlayer((int)Zone.Player1).zone--;
                                                                                    break;
                                                                                default:
                                                                                    break;
                                                                            }
                                                                        }
                                                                        if (player == 1)
                                                                        {
                                                                            TerritoryGridManager.Instance.ChangeZone(i, j, Zone.Player1);
                                                                        }
                                                                        else
                                                                        {
                                                                            TerritoryGridManager.Instance.ChangeZone(i, j, Zone.Player2);

                                                                        }
                                                                    }

                                                                    GridManager.Instance.ActivateParticles(new Vector2Int(i, j), player);
                                                                }
                                                            }
                                                        }
                                                        rangeXPlus += 2;
                                                    }
                                                }
                                                rangeYPlus += 2;
                                            }
                                        }
                                        rangeXMinus += 2;
                                    }
                                }
                                rangeYMinus += 2;
                            }
                        }
                        multiplier += 2;
                    }
                }
                y += 2;
            }
            x += 2;
        }
    }
}

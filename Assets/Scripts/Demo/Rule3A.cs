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

    public void MovePiece(Vector2Int arrayPos, Vector2Int destination) {
        UnitGrid.Instance.unitGrid[destination.x, destination.y] = UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y];
      //  UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y] = ;
        UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y] = new BasePawnsClass();

    }
    /// <summary>
    /// Coroutine for movement lerp.
    /// </summary>
    /// <param name="isMoving">Set to false when calling on inanimate object</param>
    /// <param name="toMove">The unit's GameObject to be moved</param>
    /// <param name="destination">The GameObject of the grid component chosen</param>
    /// <param name="time">Time it takes to complete trajectory</param>
    public IEnumerator LerpMovementTool(bool isMoving, GameObject toMove, GameObject destination, float time) {
        if (!isMoving)
        {                     
            isMoving = true;               
            float t = 0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime / time;
                toMove.transform.position = Vector3.Lerp(toMove.transform.position, destination.transform.position, t);
                yield return new WaitForSeconds(0.1f);  
            }
            isMoving = false;            
        }
    }

    public void RunMovementCheck(Vector2Int arrayPos, int range) {
        List<Vector2Int> potentialDestinations = new List<Vector2Int>();

        for (int s = range; s >= 0; s -= 2) {
            if (arrayPos.x - s >= 0) {
                for (int x = range; x > 0; x -= 2)
                {
                    if (UnitGrid.Instance.GetUnitGO(new Vector2Int(arrayPos.x - x, arrayPos.y)) == null)
                    {
                        GridManager.Instance.ActivateParticles(new Vector2Int(arrayPos.x - x, arrayPos.y), 0); //Activate light particle for potential destination approved
                    }
                }
            }
            if (arrayPos.x + s <= gridLimit) {
                for (int x = range; x > 0; x -= 2)
                {
                    if (UnitGrid.Instance.GetUnitGO(new Vector2Int(arrayPos.x + x, arrayPos.y)) == null)
                    {
                        potentialDestinations.Add(new Vector2Int(arrayPos.x + x, arrayPos.y));
                        GridManager.Instance.ActivateParticles(new Vector2Int(arrayPos.x + x, arrayPos.y), 0); //Activate light particle for potential destination approved
                    }
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

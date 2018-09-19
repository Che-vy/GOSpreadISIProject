using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrid
{
    private readonly Vector3 VERTICAL_OFFSET = new Vector3(0, 0.75f, 0);
	
    public GameObject[,] unitGridGO;
    public BasePawnsClass[,] unitGrid;


    #region Singleton
    private static UnitGrid instance = null;

    private UnitGrid()
    {
    }

    public static UnitGrid Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UnitGrid();
            }
            return instance;
        }
    }
    #endregion


    public void Initialize()
    {
        int gridSize = GridManager.Instance.GetGridSize();
        unitGridGO = new GameObject[gridSize, gridSize];
        unitGrid = new BasePawnsClass[gridSize, gridSize];
    }

    public void AddUnit(Vector2Int unitIndex, int player, UnitType unitType)
    {
        unitGridGO[unitIndex.x, unitIndex.y] = UnitFactory.Instance.SpawnUnit(unitType);
        unitGridGO[unitIndex.x, unitIndex.y].transform.position = GridManager.Instance.GetGridComponentPosition(unitIndex.x, unitIndex.y).position + VERTICAL_OFFSET;
        if (player == 2)
        {
            unitGridGO[unitIndex.x, unitIndex.y].transform.rotation = new Quaternion(0, 90, 0, 0);
        }

        switch (unitType) {
            case UnitType.Bit:
                unitGrid[unitIndex.x, unitIndex.y] = new Bit(new Vector3());
                break;
            case UnitType.Kernel:
                unitGrid[unitIndex.x, unitIndex.y] = new Kernel(new Vector3());
                break;
            case UnitType.Relay:
                unitGrid[unitIndex.x, unitIndex.y] = new Relay(new Vector3());
                break;
            case UnitType.Zit:
                unitGrid[unitIndex.x, unitIndex.y] = new Zip(new Vector3());
                break;
            default:
                break;
        }
        
        unitGrid[unitIndex.x, unitIndex.y].x = unitIndex.x;
        unitGrid[unitIndex.x, unitIndex.y].y = unitIndex.y;
    }

    /// <summary>
    /// Updates the unit grid with the new position of a unit.
    /// </summary>
    /// <param name="unitInitialPosIndexA">Index A of unit at initial position</param>
    /// <param name="unitInitialPosIndexB">Index B of unit at initial position</param>
    /// <param name="unitFinalPosIndexA">Index A of unit at final position</param>
    /// <param name="unitFinalPosIndexB">Index B of unit at final position</param>
    public void UpdateUnitPosition(Vector2Int initialPosIndex, Vector2Int finalPosIndex)
    {
        unitGridGO[finalPosIndex.x, finalPosIndex.y] = unitGridGO[initialPosIndex.x, initialPosIndex.y];
        unitGridGO[initialPosIndex.x, initialPosIndex.y] = null;
        unitGrid[finalPosIndex.x, finalPosIndex.y] = unitGrid[initialPosIndex.x, initialPosIndex.y];
        unitGrid[initialPosIndex.x, initialPosIndex.y] = null;
    }

    public GameObject GetUnitGO(Vector2Int unitIndex)
    {
        return unitGridGO[unitIndex.x, unitIndex.y];
    }

    public BasePawnsClass GetUnit(Vector2Int unitIndex)
    {
        return unitGrid[unitIndex.x, unitIndex.y];
    }

    public void MoveUnitGameObject()
    {
        Debug.Log("MoveUnitGameObject method not implemented");
    }

    public void ClearGrid()
    {
        for (int i = unitGrid.GetUpperBound(0); i >= 0; i--)
        {
            for (int j = unitGrid.GetUpperBound(0); i >= 0; j--)
            {
                unitGrid[i, j] = null;
            }
        }
    }
}

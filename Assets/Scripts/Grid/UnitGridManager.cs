using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGridManager
{

    private static UnitGridManager instance = null;
    public UnitGrid unitGrid;

    #region Singleton
    private UnitGridManager()
    {
    }

    public static UnitGridManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UnitGridManager();
            }
            return instance;
        }
    }
    #endregion

    public void Initialize()
    {
       // unitGrid = new UnitGrid();
       // unitGrid.Initialize();
    }

    public void UpdateUnitGrid()
    {
        // unitGrid.UpdateUnitPosition();
    }

    public void AddUnit(int indexA, int indexB, int player, UnitType unitType)
    {
        //  unitGrid.AddUnit(indexA, indexB, player, unitType);
    }

    public void ClearUnitGrid()
    {
        //   unitGrid.ClearGrid();
    }

}

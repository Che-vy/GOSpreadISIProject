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

    }

    public void UpdateUnitGrid()
    {

    }

    public void AddUnit(int indexA, int indexB, int player, UnitType unitType)
    {

    }

    public void ClearUnitGrid()
    {

    }

}

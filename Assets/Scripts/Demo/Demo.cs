using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo
{

    readonly Vector2Int kernelP1 = new Vector2Int(8, 2);
    readonly Vector2Int kernelP2 = new Vector2Int(10, 16);

    #region Singleton
    private static Demo instance = null;

    private Demo()
    {
    }

    public static Demo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Demo();
            }
            return instance;
        }
    }
    #endregion

    public void StartDemo()
    {
        UnitGrid.Instance.AddUnit(kernelP1, 1, UnitType.Kernel);
        UnitGrid.Instance.AddUnit(kernelP2, 2, UnitType.Kernel);
<<<<<<< HEAD
        UnitGrid.Instance.AddUnit(new Vector2Int(0, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(0, 2), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(0, 4), 1, UnitType.Bit);
=======

>>>>>>> dbcf40c7b08165edb36612fd8208c58e6de1840f
        UnitGrid.Instance.AddUnit(new Vector2Int(2, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(2, 2), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(2, 4), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(4, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(4, 4), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(4, 6), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(6, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(6, 2), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(6, 4), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 14), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 16), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 14), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 12), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 10), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 12), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 10), 2, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(6, 12), 2, UnitType.Bit);


        // Rule3A.Instance.
    }
}

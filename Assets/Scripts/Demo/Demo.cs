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

        UnitGrid.Instance.AddUnit(new Vector2Int(2, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(2, 2), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(4, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(4, 2), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(14, 12), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(14, 10), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 8), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 4), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 6), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(8, 8), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 6), 1, UnitType.Bit);




        UnitGrid.Instance.AddUnit(new Vector2Int(10, 0), 1, UnitType.Bit);
        UnitGrid.Instance.AddUnit(new Vector2Int(10, 10), 1, UnitType.Bit);


        // Rule3A.Instance.
    }
}

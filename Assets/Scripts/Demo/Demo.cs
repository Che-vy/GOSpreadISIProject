using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo {

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { Bit, Zit, Relay, Kernel, Template }
public class UnitFactory
{
    #region Singleton
    private static UnitFactory instance = null;

    private UnitFactory()
    {
    }

    public static UnitFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UnitFactory();
            }
            return instance;
        }
    }
    #endregion

    Dictionary<string, GameObject> units;

    public void Initialize()
    {
        //Load all the prefabs of unit
        Object[] temp = Resources.LoadAll("Prefabs/Units");
        units = new Dictionary<string, GameObject>();

        //add the prefabs in a dictionnary
        foreach (GameObject gameObject in temp)
        {
            units.Add(gameObject.name, gameObject);
        }
    }

    /// <summary>
    /// Return the Instance of the UnitType
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>

    public GameObject SpawnUnit(UnitType unit)
    {
        return GameObject.Instantiate(units[unit.ToString()]);
    }
}

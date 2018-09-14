using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager  {

    private static PlayerManager instance = null;

    private PlayerManager()
    {
    }

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }

    public void initialization()
    {

    }

    public void Update()
    {
        Debug.Log("Update in PlayerManager");
    }



    public static void ClosePlayerManager()
    {
        instance = null;
    }
}

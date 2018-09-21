using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLinks
{

    private static GameLinks instance = null;

    private GameLinks()
    {
    }

    public static GameLinks Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameLinks();
            }
            return instance;
        }
    }


    public ConnectionManager co;


}

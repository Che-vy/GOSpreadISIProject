﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {

    private static UIManager instance = null;
    private GameUI gui;

    private UIManager()
    {
        gui = GameFlow.uiLinks.gui;
    }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    public void Initialization()
    {
      
        gui.Initialize();
    }

    public void Update()
    {
        gui.UpdateGameUI();
    }
}

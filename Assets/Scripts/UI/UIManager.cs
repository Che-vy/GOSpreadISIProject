using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

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

    public void ShowUnitsUI(PawnTypes unitType)
    {
        switch (unitType)
        {
            case PawnTypes.Bit:
                goto case PawnTypes.Zip;
            case PawnTypes.Zip:
                goto case PawnTypes.Relay;
            case PawnTypes.Relay:
                break;
            case PawnTypes.Kernel:
                if (!GameFlow.uiLinks.kui.activeSelf)
                    gui.ShowKernelUI();
                break;
            default:
                Debug.Log("Unit Type unhandeled : " + unitType);
                break;
        }
    }
    public void HideUnitsUI(PawnTypes unitType)
    {
        switch (unitType)
        {
            case PawnTypes.Bit:
                goto case PawnTypes.Zip;
            case PawnTypes.Zip:
                goto case PawnTypes.Relay;
            case PawnTypes.Relay:
                break;
            case PawnTypes.Kernel:
                if (GameFlow.uiLinks.kui.activeSelf)
                    gui.HideKernelUI();
                break;
            default:
                Debug.Log("Unit Type unhandeled : " + unitType);
                break;
        }
    }
}

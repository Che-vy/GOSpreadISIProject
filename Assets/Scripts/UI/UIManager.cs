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
                if (!GameFlow.uiLinks.unitUi.activeSelf)
                    gui.ShowUnitUI();
                if (GameFlow.uiLinks.kernelUi.activeSelf)
                    gui.HideKernelUI();
                break;
            case PawnTypes.Kernel:
                if (!GameFlow.uiLinks.kernelUi.activeSelf)
                    gui.ShowKernelUI();
                if (GameFlow.uiLinks.unitUi.activeSelf)
                    gui.HideUnitUI();
                if (GameFlow.uiLinks.upgradeUi.activeSelf)
                    gui.HideUpgradeUI();
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
                if (GameFlow.uiLinks.unitUi.activeSelf)
                    gui.HideUnitUI();
                break;
            case PawnTypes.Kernel:
                if (GameFlow.uiLinks.kernelUi.activeSelf)
                    gui.HideKernelUI();
                break;
            default:
                Debug.Log("Unit Type unhandeled : " + unitType);
                break;
        }
    }


}
